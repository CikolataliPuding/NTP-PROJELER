using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task<int> Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if (args.Length == 0)
        {
            Console.WriteLine("Kullanım:");
            Console.WriteLine("  Server: dotnet run -- server [port]");
            Console.WriteLine("  Client: dotnet run -- client <kullanıcıAdı> <sunucuIP> <port>");
            return 1;
        }

        var mod = args[0].ToLowerInvariant();
        if (mod == "server")
        {
            int port = args.Length >= 2 && int.TryParse(args[1], out var p) ? p : 5000;
            await RunServerAsync(port);
        }
        else if (mod == "client")
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Kullanım: dotnet run -- client <kullanıcıAdı> <sunucuIP> <port>");
                return 1;
            }
            string kullanici = args[1];
            string host = args[2];
            if (!int.TryParse(args[3], out var port)) { Console.WriteLine("Geçersiz port."); return 1; }
            await RunClientAsync(kullanici, host, port);
        }
        else
        {
            Console.WriteLine("Geçersiz mod. 'server' veya 'client' kullan.");
            return 1;
        }

        return 0;
    }

    // ---------- SERVER ----------
    private static async Task RunServerAsync(int port)
    {
        var cts = new CancellationTokenSource();
        Console.CancelKeyPress += (s, e) => { e.Cancel = true; cts.Cancel(); };

        var dinleyici = new TcpListener(IPAddress.Any, port);
        dinleyici.Start();
        Console.WriteLine($"[SERVER] {port} portunda dinliyorum... (CTRL+C ile durdur)");

        // Sunucu tarafı da mesaj gönderebilsin
        _ = Task.Run(async () =>
        {
            while (!cts.Token.IsCancellationRequested)
            {
                string? girdi = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(girdi)) continue;
                await BroadcastAsync(istemciler, $"[SERVER] {girdi}");
            }
        });


        // aktif istemciler: id -> (TcpClient, Nick, Writer)
        var istemciler = new ConcurrentDictionary<Guid, (TcpClient tcp, string nick, StreamWriter yazici)>();

        try
        {
            while (!cts.IsCancellationRequested)
            {
                // Bekleme task’ını cancel edilebilir yapmak için timeout’lı kabul
                if (!dinleyici.Pending())
                {
                    await Task.Delay(50, cts.Token);
                    continue;
                }

                var tcp = await dinleyici.AcceptTcpClientAsync(cts.Token);
                _ = Task.Run(async () =>
                {
                    Guid id = Guid.NewGuid();
                    using var ag = tcp;
                    try
                    {
                        using var ns = ag.GetStream();
                        using var okuyucu = new StreamReader(ns, Encoding.UTF8, false, 1024, leaveOpen: true);
                        var yazici = new StreamWriter(ns, new UTF8Encoding(false)) { AutoFlush = true };

                        // İlk satır: kullanıcı adı
                        string? nick = await okuyucu.ReadLineAsync();
                        if (string.IsNullOrWhiteSpace(nick)) return;
                        istemciler[id] = (ag, nick!, yazici);

                        await BroadcastAsync(istemciler, $"** {nick} sohbete katıldı **");

                        // Mesaj dinleme döngüsü
                        string? satir;
                        while ((satir = await okuyucu.ReadLineAsync()) != null)
                        {
                            satir = satir.TrimEnd();
                            if (satir.Length == 0) continue;
                            await BroadcastAsync(istemciler, $"[{nick}] {satir}");
                        }
                    }
                    catch { /* istemci düştü vs. */ }
                    finally
                    {
                        if (istemciler.TryRemove(id, out var bilgi))
                        {
                            try { await BroadcastAsync(istemciler, $"** {bilgi.nick} ayrıldı **"); } catch { }
                        }
                    }
                }, cts.Token);
            }
        }
        catch (OperationCanceledException) { }
        finally
        {
            dinleyici.Stop();
            Console.WriteLine("[SERVER] Kapandı.");
        }
    }

    private static Task BroadcastAsync(ConcurrentDictionary<Guid, (TcpClient tcp, string nick, StreamWriter yazici)> istemciler, string mesaj)
    {
        var tasks = new System.Collections.Generic.List<Task>(istemciler.Count);
        foreach (var kv in istemciler)
        {
            try
            {
                tasks.Add(kv.Value.yazici.WriteLineAsync(mesaj));
            }
            catch { /* tek tek patlarsa görmezden gel */ }
        }
        return Task.WhenAll(tasks);
    }

    // ---------- CLIENT ----------
    private static async Task RunClientAsync(string kullanici, string host, int port)
    {
        using var tcp = new TcpClient();
        Console.WriteLine($"[CLIENT] {host}:{port} adresine bağlanılıyor...");
        await tcp.ConnectAsync(host, port);

        using var ns = tcp.GetStream();
        using var okuyucu = new StreamReader(ns, Encoding.UTF8, false, 1024, leaveOpen: true);
        using var yazici = new StreamWriter(ns, new UTF8Encoding(false)) { AutoFlush = true };

        // İlk satırda kullanıcı adını gönder
        await yazici.WriteLineAsync(kullanici);

        // Sunucudan gelenleri ayrı task’ta dinle
        var cts = new CancellationTokenSource();
        var dinleme = Task.Run(async () =>
        {
            try
            {
                string? satir;
                while ((satir = await okuyucu.ReadLineAsync()) != null)
                {
                    Console.WriteLine(satir);
                }
            }
            catch { }
            finally
            {
                cts.Cancel();
            }
        }, cts.Token);

        Console.WriteLine($"[CLIENT] Bağlandı. Mesaj yaz; çıkış için /quit");
        while (!cts.IsCancellationRequested)
        {
            string? girdi = Console.ReadLine();
            if (girdi == null) break;
            if (girdi.Trim().Equals("/quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
            await yazici.WriteLineAsync(girdi);
        }

        try { tcp.Close(); } catch { }
        try { cts.Cancel(); } catch { }
        await Task.WhenAny(dinleme, Task.Delay(1000));
        Console.WriteLine("[CLIENT] Çıkıldı.");
    }
}

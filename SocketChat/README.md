# 🧩 SocketChat – Çok Kullanıcılı Sohbet Uygulaması

Bu proje, **C# (.NET 8)** kullanılarak hazırlanmış basit bir **TCP Socket tabanlı sohbet uygulamasıdır**.  
Birden fazla istemci aynı sunucuya bağlanabilir ve mesajlarını gerçek zamanlı paylaşabilir.

---

## 🚀 Nasıl Çalışır

Uygulama hem **sunucu (server)** hem de **istemci (client)** olarak çalışabilir.  
Program hangi modda açılacağını, **komut satırı bağımsız değişkenleri** (arguments) üzerinden anlar.

### 🔹 Server başlatmak için:

server 5000

### 🔹 Client başlatmak için:

client <KullanıcıAdı> <SunucuIP> <Port>


**Örnek:**

client Egemen 127.0.0.1 5000

---

## ⚠️ Önemli Not

- **Server ve Client aynı anda tek pencerede çalıştırılamaz.**  
  Her biri **ayrı bir terminal veya Visual Studio oturumu** olarak açılmalıdır.  
- Önce **Server** başlatılmalı, ardından **Client** bağlanmalıdır.  
- Server konsoluna yazılan mesajlar tüm istemcilere yayınlanır.  

---

## 🧠 Özellikler

- Birden fazla kullanıcı aynı anda bağlanabilir.  
- Server üzerinden tüm kullanıcılara mesaj gönderilebilir.  
- İstemci `/quit` komutuyla sohbetten ayrılabilir.  
- UTF-8 karakter desteği (Türkçe karakterler dahil).  

---

## 📜 Geliştirici Notu

Bu proje, NTP dersi kapsamında **socket programlama mantığını** göstermek amacıyla geliştirilmiştir.  
Kod tamamen açık, sade ve genişletilebilir yapıdadır.  
İleride özel mesaj, kanal sistemi, kullanıcı listesi veya WinForms arayüzü eklenebilir.

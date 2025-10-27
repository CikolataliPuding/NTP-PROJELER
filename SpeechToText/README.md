# SpeechToText

Konuşmayı metne dönüştüren basit bir Windows uygulaması.

## Özellikler

- 🎤 **İki farklı Speech Engine desteği:**
  - Windows Speech Recognition (Yerel)
  - Azure Speech Service (Bulut tabanlı)

- 🔊 **Gerçek zamanlı ses tanıma**
- 📊 **Ses seviyesi göstergesi**
- 🧪 **Mikrofon test özelliği**

## Gereksinimler

- .NET 8.0
- Windows 10/11
- Mikrofon
- Azure Speech Service (opsiyonel)

## Kurulum

1. Projeyi klonlayın
2. `dotnet restore` komutu ile paketleri yükleyin
3. `dotnet build` ile projeyi derleyin
4. `dotnet run` ile uygulamayı çalıştırın

## Azure Speech Service Kurulumu (Opsiyonel)

Azure Speech Service kullanmak isterseniz:

1. [Azure Portal](https://portal.azure.com)'a gidin
2. "Cognitive Services" arayın ve seçin
3. "Speech Services" oluşturun
4. Subscription Key ve Region bilgilerini alın
5. `AzureSpeechForm.cs` dosyasında bu bilgileri güncelleyin:

```csharp
private const string SpeechKey = "YOUR_AZURE_SPEECH_KEY";
private const string SpeechRegion = "YOUR_AZURE_REGION";
```

## Kullanım

1. Uygulamayı başlatın
2. "START" butonuna tıklayın
3. Mikrofonunuza konuşun
4. Metin otomatik olarak ekranda görünecek
5. "STOP" ile dinlemeyi durdurun

## Teknik Detaylar

- **Framework:** .NET 8.0 Windows Forms
- **Speech Libraries:** 
  - System.Speech (Windows yerel)
  - Microsoft.CognitiveServices.Speech (Azure)
- **Dil:** İngilizce (en-US)
- **Platform:** Windows

## Sorun Giderme

- Mikrofon çalışmıyorsa "Test Mic" butonunu kullanın
- Windows mikrofon izinlerini kontrol edin
- Azure Speech Service için internet bağlantısı gereklidir

## Lisans

Bu proje eğitim amaçlıdır.

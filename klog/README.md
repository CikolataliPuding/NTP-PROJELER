# https://youtu.be/WxrUxxL0YJM deneme videosu




# Logger-Proje (Etik Kullaným Ýçin)

> ?? **UYARI — ÖNEMLÝ**  
> Bu araç **asla** izinsiz, habersiz veya kötü niyetli amaçlarla kullanýlmamalýdýr. Bu proje **sadece** yazýlý, açýk ve belgelendirilmiþ izin ile yapýlan güvenlik testleri, eðitim ve laboratuvar çalýþmalarý için hazýrlanmýþtýr. Ýzinsiz kullaným suçtur ve cezai/medenî sorumluluk doðurur.

## Ne iþe yarar
Kýsaca: Bu proje, **yetkili** ortamlarda olay günlüklemesi / davranýþ analizi / hata ayýklama amaçlarý için örnek bir *logger* iskeleti sunar. Bu README, güvenlik, yasal uyumluluk ve sorumlu kullanýma dair önemli uyarýlar içerir.

## Önemli Uyarýlar
- **YAZILI ÝZÝN OLMADAN KULLANMAK SUÇTUR.** Cihaz sahibinin açýk onayý yoksa bu yazýlým asla çalýþtýrýlmamalýdýr.  
- Bu projeyi sadece izole edilmiþ bir test laboratuvarýnda (VM, sandbox) veya açýkça yetki verilmiþ hedeflerde kullanýn.  
- Toplanan verilerin gizliliði, saklanma süresi ve eriþimi için net bir politika oluþturun. Verileri gereksiz yere saklamayýn.  
- Yasal gereklilikleri (ülke yasalarý, KVKK/ GDPR benzeri düzenlemeler) araþtýrýn ve uyun.

## Hedef Kullaným Senaryolarý (Yasal ve Etik)
- Kurumsal iç test laboratuvarýnda uygulama davranýþ analizi.  
- Güvenlik eðitimi ve CTF ortamlarý (katýlýmcýlarýn rýzasýyla).  
- Forensik/olay müdahalesi çalýþmalarý — sadece yetkili ekiplerce.  

## Kurulum (Genel — Örnek)
> Not: Burada teknik detay yok. Uygulamayý çalýþtýrmadan önce mutlaka yazýlý izin ve test ortamý doðrulanmalýdýr.

1. Proje dosyalarýný izole bir VM'e kopyalayýn.  
2. Gerekli baðýmlýlýklarý yalnýzca güvenli, iç kaynaklardan kurun.  
3. Çalýþtýrmadan önce hedef ortamýn izinlerini belgeleyin (yazýlý izin).

## Veri Yönetimi
- Hangi verilerin toplandýðýný açýkça belgeleyin.  
- Hassas verileri anonimleþtirin veya toplamayýn.  
- Veri saklama süresini kýsaltýn; gereksiz verileri hemen silin.  
- Eriþim kontrolleri, kayýt tutma ve þifreleme uygulayýn.

## Güvenlik ve Sorumluluk
- Kodu üçüncü þahýslara daðýtýrken dikkatli olun.  
- Güvenlik açýklarýný sorumlu þekilde ifþa edin (Responsible Disclosure).  
- Projeyi kötüye kullananlarý rapor etmek için kurum içi prosedürleri takip edin.

## Kaldýrma / Temizleme
- Test ortamý dýþýnda kullanýlmadýðýndan emin olduktan sonra tüm loglarý güvenli biçimde silin.  
- VM veya fiziksel ortam kaldýrýlacaksa imajý güvenli þekilde yok edin.

## Yasal Uyarý ve Sorumluluk Reddi
Bu proje sahibinin veya hazýrlayanýn, kullanýcýlarýn yazýlýmý nasýl kullandýklarýndan dolayý hiçbir sorumluluðu yoktur. Yazýlýmýn izinsiz veya yasa dýþý kullanýmý tamamen kullanýcý sorumluluðundadýr. Yazýlý izin olmadan kullanmayýn.

## Ýletiþim
Herhangi bir þüphede veya yasal/etik soruda, proje sorumlusu / kurum hukuku ile iletiþime geçin.

---

**Kýsa versiyon:** Yazýlý izin ? izole test ortamý ? veri koruma ? sorumluluk. Baþka türlü YAPMAYIN.

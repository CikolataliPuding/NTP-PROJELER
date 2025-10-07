# https://youtu.be/WxrUxxL0YJM deneme videosu




# Logger-Proje (Etik Kullan�m ��in)

> ?? **UYARI � �NEML�**  
> Bu ara� **asla** izinsiz, habersiz veya k�t� niyetli ama�larla kullan�lmamal�d�r. Bu proje **sadece** yaz�l�, a��k ve belgelendirilmi� izin ile yap�lan g�venlik testleri, e�itim ve laboratuvar �al��malar� i�in haz�rlanm��t�r. �zinsiz kullan�m su�tur ve cezai/meden� sorumluluk do�urur.

## Ne i�e yarar
K�saca: Bu proje, **yetkili** ortamlarda olay g�nl�klemesi / davran�� analizi / hata ay�klama ama�lar� i�in �rnek bir *logger* iskeleti sunar. Bu README, g�venlik, yasal uyumluluk ve sorumlu kullan�ma dair �nemli uyar�lar i�erir.

## �nemli Uyar�lar
- **YAZILI �Z�N OLMADAN KULLANMAK SU�TUR.** Cihaz sahibinin a��k onay� yoksa bu yaz�l�m asla �al��t�r�lmamal�d�r.  
- Bu projeyi sadece izole edilmi� bir test laboratuvar�nda (VM, sandbox) veya a��k�a yetki verilmi� hedeflerde kullan�n.  
- Toplanan verilerin gizlili�i, saklanma s�resi ve eri�imi i�in net bir politika olu�turun. Verileri gereksiz yere saklamay�n.  
- Yasal gereklilikleri (�lke yasalar�, KVKK/ GDPR benzeri d�zenlemeler) ara�t�r�n ve uyun.

## Hedef Kullan�m Senaryolar� (Yasal ve Etik)
- Kurumsal i� test laboratuvar�nda uygulama davran�� analizi.  
- G�venlik e�itimi ve CTF ortamlar� (kat�l�mc�lar�n r�zas�yla).  
- Forensik/olay m�dahalesi �al��malar� � sadece yetkili ekiplerce.  

## Kurulum (Genel � �rnek)
> Not: Burada teknik detay yok. Uygulamay� �al��t�rmadan �nce mutlaka yaz�l� izin ve test ortam� do�rulanmal�d�r.

1. Proje dosyalar�n� izole bir VM'e kopyalay�n.  
2. Gerekli ba��ml�l�klar� yaln�zca g�venli, i� kaynaklardan kurun.  
3. �al��t�rmadan �nce hedef ortam�n izinlerini belgeleyin (yaz�l� izin).

## Veri Y�netimi
- Hangi verilerin topland���n� a��k�a belgeleyin.  
- Hassas verileri anonimle�tirin veya toplamay�n.  
- Veri saklama s�resini k�salt�n; gereksiz verileri hemen silin.  
- Eri�im kontrolleri, kay�t tutma ve �ifreleme uygulay�n.

## G�venlik ve Sorumluluk
- Kodu ���nc� �ah�slara da��t�rken dikkatli olun.  
- G�venlik a��klar�n� sorumlu �ekilde if�a edin (Responsible Disclosure).  
- Projeyi k�t�ye kullananlar� rapor etmek i�in kurum i�i prosed�rleri takip edin.

## Kald�rma / Temizleme
- Test ortam� d���nda kullan�lmad���ndan emin olduktan sonra t�m loglar� g�venli bi�imde silin.  
- VM veya fiziksel ortam kald�r�lacaksa imaj� g�venli �ekilde yok edin.

## Yasal Uyar� ve Sorumluluk Reddi
Bu proje sahibinin veya haz�rlayan�n, kullan�c�lar�n yaz�l�m� nas�l kulland�klar�ndan dolay� hi�bir sorumlulu�u yoktur. Yaz�l�m�n izinsiz veya yasa d��� kullan�m� tamamen kullan�c� sorumlulu�undad�r. Yaz�l� izin olmadan kullanmay�n.

## �leti�im
Herhangi bir ��phede veya yasal/etik soruda, proje sorumlusu / kurum hukuku ile ileti�ime ge�in.

---

**K�sa versiyon:** Yaz�l� izin ? izole test ortam� ? veri koruma ? sorumluluk. Ba�ka t�rl� YAPMAYIN.

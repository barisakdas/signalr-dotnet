# Web Projesine SignalR Ekleme
SignalR�� bir web projesine eklemek i�in iki yayg�n y�ntem bulunmaktad�r: 
`CDN (Content Delivery Network)` kullanarak ve `NPM (Node Package Manager)` arac�l���yla. 
��te her iki y�ntem i�in ad�m ad�m bir rehber:

* CDN ile SignalR Ekleme
CDN kullanarak SignalR�� projenize eklemek, h�zl� ve kolay bir y�ntemdir. 
* Bu y�ntem, SignalR JavaScript k�t�phanesini bir CDN �zerinden do�rudan web sayfan�za dahil etmenizi sa�lar.

1. SignalR JavaScript K�t�phanesini Dahil Etme: HTML dosyan�z�n <head> b�l�m�ne a�a��daki <script> etiketini ekleyin:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/3.1.9/signalr.min.js"></script>
```

2. SignalR Ba�lant�s�n� Kurma: JavaScript dosyan�zda, SignalR hub��n�za ba�lanmak i�in bir ba�lant� olu�turun:

```jscript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub") // Sunucu taraf�ndaki Hub yolu
    .configureLogging(signalR.LogLevel.Information)
    .build();
```

3. Ba�lant�y� Ba�latma: Ba�lant�y� ba�latmak ve sunucu ile ileti�ime ge�mek i�in:

```jscript
connection.start().catch(function (err) {
    return console.error(err.toString());
});
```

* NPM ile SignalR Ekleme
NPM, Node.js projeleri i�in paket y�neticisidir. SignalR�� NPM arac�l���yla projenize eklemek, �zellikle modern JavaScript �at�lar� (frameworks) kullan�yorsan�z tercih edilen bir y�ntemdir.

1. SignalR Paketini Y�kleme: Komut sat�r�n� a��n ve projenizin k�k dizininde a�a��daki komutu �al��t�r�n:
```bash
npm install @microsoft/signalr
```

2. SignalR�� Projeye Dahil Etme: JavaScript dosyan�zda, SignalR�� projenize dahil edin:
```bash
import * as signalR from "@microsoft/signalr";
```

SignalR Ba�lant�s�n� Kurma ve Ba�latma: Ba�lant�y� kurmak ve ba�latmak i�in yukar�daki CDN ile yap�lan ad�mlar� takip edin.
Her iki y�ntem de SignalR�� web projenize entegre etmek i�in etkili ��z�mler sunar. CDN, h�zl� bir ba�lang�� i�in idealdir, 
ancak NPM, paket ba��ml�l�klar�n�z� daha iyi y�netmenizi ve projenizi daha kolay �l�eklendirmenizi sa�lar. Projenizin gereksinimlerine 
ve geli�tirme ortam�n�za ba�l� olarak en uygun olan� se�ebilirsiniz. 
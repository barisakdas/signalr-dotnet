# Web Projesine SignalR Ekleme
SignalR’ý bir web projesine eklemek için iki yaygýn yöntem bulunmaktadýr: 
`CDN (Content Delivery Network)` kullanarak ve `NPM (Node Package Manager)` aracýlýðýyla. 
Ýþte her iki yöntem için adým adým bir rehber:

* CDN ile SignalR Ekleme
CDN kullanarak SignalR’ý projenize eklemek, hýzlý ve kolay bir yöntemdir. 
* Bu yöntem, SignalR JavaScript kütüphanesini bir CDN üzerinden doðrudan web sayfanýza dahil etmenizi saðlar.

1. SignalR JavaScript Kütüphanesini Dahil Etme: HTML dosyanýzýn <head> bölümüne aþaðýdaki <script> etiketini ekleyin:

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/3.1.9/signalr.min.js"></script>
```

2. SignalR Baðlantýsýný Kurma: JavaScript dosyanýzda, SignalR hub’ýnýza baðlanmak için bir baðlantý oluþturun:

```jscript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub") // Sunucu tarafýndaki Hub yolu
    .configureLogging(signalR.LogLevel.Information)
    .build();
```

3. Baðlantýyý Baþlatma: Baðlantýyý baþlatmak ve sunucu ile iletiþime geçmek için:

```jscript
connection.start().catch(function (err) {
    return console.error(err.toString());
});
```

* NPM ile SignalR Ekleme
NPM, Node.js projeleri için paket yöneticisidir. SignalR’ý NPM aracýlýðýyla projenize eklemek, özellikle modern JavaScript çatýlarý (frameworks) kullanýyorsanýz tercih edilen bir yöntemdir.

1. SignalR Paketini Yükleme: Komut satýrýný açýn ve projenizin kök dizininde aþaðýdaki komutu çalýþtýrýn:
```bash
npm install @microsoft/signalr
```

2. SignalR’ý Projeye Dahil Etme: JavaScript dosyanýzda, SignalR’ý projenize dahil edin:
```bash
import * as signalR from "@microsoft/signalr";
```

SignalR Baðlantýsýný Kurma ve Baþlatma: Baðlantýyý kurmak ve baþlatmak için yukarýdaki CDN ile yapýlan adýmlarý takip edin.
Her iki yöntem de SignalR’ý web projenize entegre etmek için etkili çözümler sunar. CDN, hýzlý bir baþlangýç için idealdir, 
ancak NPM, paket baðýmlýlýklarýnýzý daha iyi yönetmenizi ve projenizi daha kolay ölçeklendirmenizi saðlar. Projenizin gereksinimlerine 
ve geliþtirme ortamýnýza baðlý olarak en uygun olaný seçebilirsiniz. 
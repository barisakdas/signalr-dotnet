# SignalR Real-Time Communication Project

## Proje Hakkında

Bu proje, .NET 8 API kullanarak gerçek zamanlı iletişim sağlayan bir sunucu, bir Worker Service ve MVC Web tabanlı iki istemci içermektedir. SignalR kütüphanesi, veri akışlarını ve kullanıcı etkileşimlerini anlık olarak yönetmek için kullanılmaktadır.

## Amacımız

Projemizin temel amacı, gerçek zamanlı uygulamaların nasıl oluşturulacağını ve yönetileceğini göstermektir. SignalR'ın güçlü özelliklerini kullanarak, kullanıcıların birbiriyle etkileşimde bulunabileceği dinamik bir platform sunmayı hedefliyoruz.

## Motivasyon

Gerçek zamanlı veri akışının önemi günümüzde giderek artmaktadır. Bu proje, bu ihtiyaca yanıt vermek ve geliştiricilere SignalR ile çalışma konusunda rehberlik etmek için tasarlanmıştır.

## Projede Verilen Örnekler

- **.NET 8 API Sunucusu:** Bu sunucu, SignalR Hub'ını barındırır ve istemciler arasındaki iletişimi yönetir. Gerçek zamanlı veri akışını ve etkileşimli kullanıcı deneyimlerini mümkün kılar.
- **Worker Service:** Uygulamanın arka plan işlemlerini yürütür. Bu servis, uzun süreli işlemleri ve zaman alıcı görevleri etkin bir şekilde yönetir.
- **MVC Web İstemcileri:** Kullanıcıların web üzerinden sunucuyla etkileşime girebildiği iki ayrı istemci uygulamasıdır. Bu istemciler, kullanıcıların mesajlaşmasını ve sunucu tarafındaki veri akışlarını takip etmesini sağlar.

### Sunucu Örneği

.NET 8 API ile oluşturulan sunucu, SignalR Hub'ını barındırır ve istemciler arası iletişimi koordine eder.

```csharp
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
```

### Worker Service Örneği
Arka plan işlemleri ve sunucu tarafı mantığı için kullanılır.

```csharp
public class Worker : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // Arka plan işlemleri
        }
    }
}
```

### MVC Web İstemcisi Örneği
Kullanıcıların mesajlaşmasını ve sunucu ile etkileşimde bulunmasını sağlayan web istemcisi.

```html
@{
    ViewData["Title"] = "Chat Page";
}

<div id="chatWindow">
    <!-- Chat mesajları burada görüntülenecek -->
</div>

<input type="text" id="messageInput" />
<button onclick="sendMessage()">Gönder</button>

@section Scripts {
    <script src="~/js/chat.js"></script>
}
```

## Nasıl Kullanılır

Projeyi kullanmak için aşağıdaki adımları takip edin:

1. Projeyi GitHub'dan klonlayın.
2. Gerekli paketleri yükleyin.
3. Sunucu ve istemcileri başlatın.
4. Web istemcileri üzerinden sunucuya bağlanın ve gerçek zamanlı iletişimi deneyimleyin.

## Nasıl Geliştirilir

Projeyi geliştirmek için aşağıdaki yönergeleri izleyebilirsiniz:

1. Yeni özellikler eklemek için sunucu ve istemci kodlarını inceleyin.
2. SignalR dokümantasyonunu kullanarak yeni Hub metodları oluşturun.
3. MVC istemcilerine yeni kullanıcı arayüzleri ekleyin.
4. Worker Service'i genişleterek arka plan işlemlerini optimize edin.

## Katkıda Bulunma

Projeye katkıda bulunmak isteyenler için:

1. İssue tracker üzerinden mevcut sorunları inceleyin.
2. Forklayın ve özellik/fix branch'leri oluşturun.
3. Pull request gönderin.

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır.

---

Bu `README.md` dosyası, projenizin genel bir özetini ve nasıl kullanılacağına dair temel bilgileri içermektedir. Daha fazla detay eklemek veya özelleştirmek isterseniz, lütfen bana bildirin. Yardımcı olmaktan mutluluk duyarım!

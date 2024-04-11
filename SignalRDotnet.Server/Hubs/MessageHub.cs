using Microsoft.AspNetCore.SignalR;

namespace SignalRDotnet.Server.Hubs;

/// <summary>
/// MessageHub, SignalR altyapısını kullanarak gerçek zamanlı mesajlaşma işlevselliği sağlayan bir hub sınıfıdır.
/// İstemcilerin sunucuya bağlanmasını, mesaj göndermesini ve almasını sağlar.
/// Ayrıca, istemcileri gruplara ekleyip çıkarmak ve gelen mesajları işleyip geri göndermek gibi işlemleri destekler.
/// </summary>
public class MessageHub : Hub<IMessageHub>
{
    /// <summary>Tüm bağlı istemcilere mesaj gönderir.</summary>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToAll(string message)
        => await Clients.All.ReceiveMessage(message);

    /// <summary>Sadece istek yapan istemciye mesaj gönderir.</summary>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToCaller(string message)
        => await Clients.Caller.ReceiveMessage(message);

    /// <summary>Sadece istek yapan istemciye mesaj gönderir.</summary>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToOther(string message)
        => await Clients.Others.ReceiveMessage(message);

    /// <summary>Belirli bir gruptaki istemcilere mesaj gönderir.</summary>
    /// <param name="groupName">Mesajın gönderileceği grup adı.</param>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToGroup(string groupName, string message)
        => await Clients.Group(groupName).ReceiveMessageFromGroup(message);

    /// <summary>Belirli bir istemciye mesaj gönderir.</summary>
    /// <param name="connectionId">Mesajın gönderileceği istemcinin bağlantı kimliği.</param>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToClient(string connectionId, string message)
        => await Clients.Client(connectionId).ReceiveMessage(message);

    /// <summary>Bir istemciyi belirli bir gruba ekler.</summary>
    /// <param name="groupName">Eklenecek grup adı.</param>
    public async Task AddToGroup(string groupName)
    {
        // İlgili client gruba ekleniyor.
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        // Gruba eklendiğinin bilgisi kendisine veriliyor.
        await Clients.Caller.ReceiveMessage($"{groupName} isimli gruba eklendiniz.");

        // Gruptaki diğer paydaşlara gruba eklendiğini gösteriyoruz.
        await Clients.Group(groupName).ReceiveMessage($"{Context.ConnectionId} id li kullanıcı gruba eklendi.");
    }

    /// <summary>Bir istemciyi belirli bir gruptan çıkarır.</summary>
    /// <param name="groupName">Çıkarılacak grup adı.</param>
    public async Task RemoveFromGroup(string groupName)
    {
        // İlgili client gruptan çıkartılıyor.
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        // Gruptan ayrıldığının bilgisi kendisine veriliyor.
        await Clients.Caller.ReceiveMessage($"{groupName} isimli gruptan ayrıldınız.");

        // Gruptan ayrıldığının bilgisi gruptaki diğer paydaşlara veriliyor.
        await Clients.Group(groupName).ReceiveMessage($"{Context.ConnectionId} id li kullanıcı gruptan ayrıldı.");
    }

    /// <summary>İstemcilerden gelen mesajları alır, işler ve geri gönderir.
    /// Bu metod, örneğin büyük harfe çevirme gibi basit bir işlem yapabilir.</summary>
    /// <param name="message">İşlenecek mesaj.</param>
    public async Task ProcessAndReturnMessage(string message)
    {
        var processedMessage = ProcessMessage(message);
        await Clients.Caller.ReceiveMessage(processedMessage);
    }

    /// <summary>Gelen mesaj üzerinde işlem yapar. Bu özel metod, mesajı büyük harfe çevirerek işler.</summary>
    /// <param name="message">İşlenecek mesaj.</param>
    /// <returns>İşlenmiş mesaj.</returns>
    private string ProcessMessage(string message)
    {
        return message.ToUpper();
    }

    /// <summary>İlgili hub'ı dinleyen bir client eklendiğinde tüm bağlı client'lara bildiriyoruz.</summary>
    public override async Task OnConnectedAsync()
    {
        await Clients.All.ReceiveMessage($"Bir bağlantı başarıyla sağlandı. Bağlantı id: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    /// <summary>İlgili hub'ı dinleyen bir client bağlantıyı kopardığında tüm bağlı client'lara bildiriyoruz.</summary>
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.ReceiveMessage($"Bir bağlantı koptu. Bağlantı id: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}
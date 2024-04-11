using Microsoft.AspNetCore.SignalR;
using SignalRDotnet.Server.Models;

namespace SignalRDotnet.Server.Hubs;

public class ProductHub : Hub<IProductHub>
{
    /// <summary>Tüm bağlı istemcilere mesaj gönderir.</summary>
    /// <param name="message">Gönderilecek mesaj.</param>
    public async Task SendMessageToAll(Product product)
        => await Clients.All.ReceiveProduct(product);
}
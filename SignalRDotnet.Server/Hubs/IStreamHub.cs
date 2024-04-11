using SignalRDotnet.Server.Models;

namespace SignalRDotnet.Server.Hubs;

public interface IStreamHub
{
    /// <summary>Bir istemciden mesaj alır ve işler.
    /// Bu metod genellikle sunucu ile tek bir istemci arasındaki doğrudan iletişimi işlemek için kullanılır.</summary>
    /// <param name="message">The message sent by the client.</param>
    Task ReceiveMessage(string message);

    Task ReceiveProduct(Product product);
}
namespace SignalRDotnet.Server.Hubs;

/// <summary>IMessageHub arayüzü, istemcilerin bağlanabileceği bir mesajlaşma merkezinin sözleşmesini tanımlar.
/// İstemcilerden gelen mesajları işlemek ve gruplara mesaj dağıtmak için hub'ın uygulayacağı metodları belirtir.</summary>
public interface IMessageHub
{
    /// <summary>Bir istemciden mesaj alır ve işler.
    /// Bu metod genellikle sunucu ile tek bir istemci arasındaki doğrudan iletişimi işlemek için kullanılır.</summary>
    /// <param name="message">The message sent by the client.</param>
    Task ReceiveMessage(string message);

    /// <summary>Bir istemciden mesaj alır ve belirli bir gruba iletir.
    /// Bu metod, bir sohbet odası veya bir takım gibi bağlı istemcilerin bir alt kümesi için tasarlanmış mesajlar olduğunda kullanılır.</summary>
    /// <param name="message">The message sent by the client to the group.</param>
    Task ReceiveMessageFromGroup(string message);
}
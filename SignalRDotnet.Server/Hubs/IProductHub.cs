using SignalRDotnet.Server.Models;

namespace SignalRDotnet.Server.Hubs;

public interface IProductHub
{
    Task ReceiveProduct(Product product);
}
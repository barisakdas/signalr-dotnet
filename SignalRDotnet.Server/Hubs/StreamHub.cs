using Microsoft.AspNetCore.SignalR;
using SignalRDotnet.Server.Models;

namespace SignalRDotnet.Server.Hubs;

public class StreamHub : Hub<IStreamHub>
{
    public async Task SendMessageToAll(IAsyncEnumerable<string> nameAsChunks)
    {
        await foreach (var name in nameAsChunks)
        {
            await Task.Delay(1000);
            await Clients.All.ReceiveMessage(name);
        }
    }

    public async Task SendProductToAll(IAsyncEnumerable<Product> productAsChunks)
    {
        await foreach (var product in productAsChunks)
        {
            await Task.Delay(1000);
            await Clients.All.ReceiveProduct(product);
        }
    }
}
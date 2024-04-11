using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRDotnet.ClientWorkerSpace;

public class Worker(
    ILogger<Worker> logger,
    IConfiguration configuration)
    : BackgroundService
{
    private HubConnection? connection;

    /// <summary>Uygulama ilk ayaða kalkarken çalýþacak metot.</summary>
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        // Baþka bir projede bulunan Hub'a baðlanmak için.
        connection = new HubConnectionBuilder()
            .WithUrl(configuration.GetSection("SignalR")["Hub"]!)
            .Build();

        connection.StartAsync()
            .ContinueWith((result)
                => Console.WriteLine(result.IsCompletedSuccessfully ? "Connected" : "Connection Failed."));

        connection.InvokeAsync("SendMessageToAll", "Bu mesaj tüm clientlara gönderilecek.");

        connection.InvokeAsync("SendMessageToAll", "Bu mesaj tüm clientlara gönderilecek.");
        return base.StartAsync(cancellationToken);
    }

    /// <summary>Bu metot uygulama ayaða kalktýðýnda sadece bir defa çalýþýr.</summary>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        connection!.On<string>("ReceiveMessage", (message) => Console.WriteLine($"Worker service client üzerine gelen mesaj: {message}"));

        return Task.CompletedTask;
    }

    /// <summary>Uygulama sonlanýrken çalýþacak metot.</summary>
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await connection!.StopAsync(cancellationToken);
        await connection!.DisposeAsync();
        base.StopAsync(cancellationToken);
    }
}
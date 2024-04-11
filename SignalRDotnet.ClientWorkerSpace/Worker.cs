using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRDotnet.ClientWorkerSpace;

public class Worker(
    ILogger<Worker> logger,
    IConfiguration configuration)
    : BackgroundService
{
    private HubConnection? connection;

    /// <summary>Uygulama ilk aya�a kalkarken �al��acak metot.</summary>
    public override Task StartAsync(CancellationToken cancellationToken)
    {
        // Ba�ka bir projede bulunan Hub'a ba�lanmak i�in.
        connection = new HubConnectionBuilder()
            .WithUrl(configuration.GetSection("SignalR")["Hub"]!)
            .Build();

        connection.StartAsync()
            .ContinueWith((result)
                => Console.WriteLine(result.IsCompletedSuccessfully ? "Connected" : "Connection Failed."));

        connection.InvokeAsync("SendMessageToAll", "Bu mesaj t�m clientlara g�nderilecek.");

        connection.InvokeAsync("SendMessageToAll", "Bu mesaj t�m clientlara g�nderilecek.");
        return base.StartAsync(cancellationToken);
    }

    /// <summary>Bu metot uygulama aya�a kalkt���nda sadece bir defa �al���r.</summary>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        connection!.On<string>("ReceiveMessage", (message) => Console.WriteLine($"Worker service client �zerine gelen mesaj: {message}"));

        return Task.CompletedTask;
    }

    /// <summary>Uygulama sonlan�rken �al��acak metot.</summary>
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await connection!.StopAsync(cancellationToken);
        await connection!.DisposeAsync();
        base.StopAsync(cancellationToken);
    }
}
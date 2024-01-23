using SenderSqs.Commons;
using SenderSQS.Commons;
using SenderSqs.Interfaces;

namespace SenderSqs.Helpers;

public static class Helper
{
    public static async Task SendMessage(string? message, ISqs sqsClient)
    {
        if (message == null || message.Length == 0) return;
        await sqsClient.SendMessage(message);
    }

    public static async Task GettingMessagesAsync(ISqs sqsClient)
    {
        Console.WriteLine("Getting messages.....");
        await Task.Delay(3000);
        var messages = await sqsClient.ReceiveMessage();
        foreach (var val in messages)
        {
            await Console.Out.WriteLineAsync(val);
        }
    }

    public static string? WriteMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Write a message: ");
        var message = Console.ReadLine();
        return message;
    }

    public static bool CheckEndApp(bool end)
    {
        Console.WriteLine();
        Console.WriteLine("Want to end(y/n)?");
        var ended = Console.ReadLine();
        if (ended != null && ended.Length > 0 && ended.ToLower() == "y")
        {
            end = true;
        }
        Console.WriteLine();
        return end;
    }

    public static Sqs StartUp()
    {
        var configuration = ConfigurationLoader.LoadConfiguration();
        var sqsClient = new Sqs(configuration);
        return sqsClient;
    }
}

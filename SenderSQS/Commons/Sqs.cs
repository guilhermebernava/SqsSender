using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Microsoft.Extensions.Configuration;
using SenderSqs.Interfaces;

namespace SenderSqs.Commons;

public class Sqs : ISqs
{
    private string _queueName;
    private readonly IAmazonSQS _client;

    public Sqs(IConfiguration configuration)
    {
        var region = RegionEndpoint.SAEast1;
        var credentials = new BasicAWSCredentials(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"]);
        _client = new AmazonSQSClient(credentials, region);
        _queueName = configuration["SQS:QueueUrl"]!;
    }

    public async Task<bool> SendMessage(string message)
    {
        try
        {
            var result = await _client.SendMessageAsync(_queueName, message);
            Console.WriteLine($"Message Sended, MessageId: {result.MessageId}");
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<string>> ReceiveMessage()
    {
        var responseMessages = await _client.ReceiveMessageAsync(new ReceiveMessageRequest
        {
            QueueUrl = _queueName,
            MaxNumberOfMessages = 5,
            WaitTimeSeconds = 0
        });
        var messages = new List<string>();

        if (responseMessages == null) return messages;


        foreach (var responseMessage in responseMessages.Messages)
        {
            messages.Add(responseMessage.Body.ToString());
        }
        return messages;
    }
}

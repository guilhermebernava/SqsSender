namespace SenderSqs.Interfaces;

public interface ISqs
{
    Task<bool> SendMessage(string message);
    Task<List<string>> ReceiveMessage();
}

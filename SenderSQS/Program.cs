using SenderSqs.Helpers;
using SenderSqs.Interfaces;

ISqs sqsClient = Helper.StartUp();
bool end = false;

while (end == false)
{
    await Helper.GettingMessagesAsync(sqsClient);
    await Helper.SendMessage(Helper.WriteMessage(), sqsClient);
    end = Helper.CheckEndApp(end);
}
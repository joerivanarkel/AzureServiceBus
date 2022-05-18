using Azure.Messaging.ServiceBus;

namespace ServiceBus;

public class ServiceBusRepository
{
    private readonly ServiceBusClient _serviceBusClient;

    public ServiceBusRepository(ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
    }

    public async Task<bool> SendMessage()
    {
        try
        {
            var serviceBusSender = _serviceBusClient.CreateSender("testqueue");
            var sendmessage = new ServiceBusMessage("Hello, World!");
            await serviceBusSender.SendMessageAsync(sendmessage);
            Console.WriteLine($"Sent Message {sendmessage.Body}");
            await serviceBusSender.CloseAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return false;
        }

    }

    public async Task<bool> RecieveMessage()
    {
        try
        {
            var serviceBusReciever = _serviceBusClient.CreateReceiver("testqueue");
            var recievedmessage = await serviceBusReciever.ReceiveMessageAsync();

            if (recievedmessage != null)
            {
                Console.WriteLine($"Received Message {recievedmessage.Body}");
                await serviceBusReciever.CompleteMessageAsync(recievedmessage);
            }
            else
            {
                Console.WriteLine("No message to receive");
            }
            await serviceBusReciever.CloseAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
            return false;
        }
    }
}

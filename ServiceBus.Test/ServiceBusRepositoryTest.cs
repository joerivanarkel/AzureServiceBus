using Azure.Messaging.ServiceBus;
using UserSecrets;
using Xunit;

namespace ServiceBus.Test;

public class ServiceBusRepositoryTest
{
    [Fact]
    public void ShouldSendMessage()
    {
        string connectionString = UserSecrets<ServiceBusRepositoryTest>.GetSecret("connectionstring");
        ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
        ServiceBusRepository serviceBusRepository = new ServiceBusRepository(serviceBusCLient);
        var result = serviceBusRepository.SendMessage();

        Assert.True(result.Result);
    }

    [Fact]
    public void ShouldRecieveMessage()
    {
        string connectionString = UserSecrets<ServiceBusRepositoryTest>.GetSecret("connectionstring");
        ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
        ServiceBusRepository serviceBusRepository = new ServiceBusRepository(serviceBusCLient);
        serviceBusRepository.SendMessage();
        var result = serviceBusRepository.RecieveMessage();

        Assert.True(result.Result);
    }
}
using Azure.Messaging.ServiceBus;
using Xunit;

namespace ServiceBus.Test;

public class ServiceBusRepositoryTest
{
    [Fact]
    public void ShouldSendMessage()
    {
        string connectionString = SecretConfiguration.GetSecret();
        ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
        ServiceBusRepository serviceBusRepository = new ServiceBusRepository(serviceBusCLient);
        var result = serviceBusRepository.SendMessage();

        Assert.True(result.Result);
    }

    [Fact]
    public void ShouldRecieveMessage()
    {
        string connectionString = SecretConfiguration.GetSecret();
        ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
        ServiceBusRepository serviceBusRepository = new ServiceBusRepository(serviceBusCLient);
        serviceBusRepository.SendMessage();
        var result = serviceBusRepository.RecieveMessage();

        Assert.True(result.Result);
    }
}
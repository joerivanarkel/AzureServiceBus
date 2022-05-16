using Azure.Messaging.ServiceBus;
using ServiceBus;

var connectionString = SecretConfiguration.GetSecret();
ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
var serviceBusRepository = new ServiceBusRepository(serviceBusCLient);

await serviceBusRepository.SendMessage();
await serviceBusRepository.RecieveMessage();
using Azure.Messaging.ServiceBus;
using ServiceBus;
using UserSecrets;

var connectionString = UserSecrets<Program>.GetSecret("connectionstring");
ServiceBusClient serviceBusCLient = new ServiceBusClient(connectionString);
var serviceBusRepository = new ServiceBusRepository(serviceBusCLient);

await serviceBusRepository.SendMessage();
await serviceBusRepository.RecieveMessage();
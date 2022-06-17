[← Return to AZ-204](https://github.com/joerivanarkel/joerivanarkel/blob/main/AZ204.md)<br>

[![.NET](https://github.com/joerivanarkel/AzureServiceBus/actions/workflows/dotnet.yml/badge.svg)](https://github.com/joerivanarkel/AzureServiceBus/actions/workflows/dotnet.yml)

# Azure Service Bus
Sending and Receiving messages from Azure Service Bus
To work with a Azure Service Bus, you will have to use the ServiceBusClient to interact with this resource.

## Sending a Message to a Queue
To send a message to the Queue, you have to use the `ServiceBusClient` to create a Sender with the queue name. Secondly you have to create a `ServiceBusMessage`, with the message for the body. Then you await the `SendMessageAsync()` method and finally close the connection with the `CloseAsync()` method.

```csharp
var serviceBusSender = _serviceBusClient.CreateSender("testqueue");
var sendmessage = new ServiceBusMessage("Hello, World!");
await serviceBusSender.SendMessageAsync(sendmessage);
await serviceBusSender.CloseAsync();
```

## Receiving a Message from a Queue
Akin to the sender, you must first create a Receiver using the `ServiceBusClient`. Then using the `RecievedMessageAsync()` method to fetch the message, which returns the `ServiceBusReceivedMessage` type object. Then I establish that the received message isn't empty and then dequeue the message with the `CompleteMessageAsync()`, giving it the exact message. Finally is close the connection with the `CloseAsync()` method.

```csharp
var serviceBusReciever = _serviceBusClient.CreateReceiver("testqueue");
var recievedmessage = await serviceBusReciever.ReceiveMessageAsync();

if (recievedmessage != null)
{
  await serviceBusReciever.CompleteMessageAsync(recievedmessage);
}

await serviceBusReciever.CloseAsync();
```

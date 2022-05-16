# Azure Service Bus
Sending and Recieving messages from Azure Service Bus
To work with a Azure Service Bus, you will have to use the ServiceBusClient to interact with this resource.

## Sending a Message to a Queue
To send a message to the Queue, you have to use the `ServiceBusClient` to create a Sender with the queuename. Secondly you ahve to create a `ServiceBusMessage`, with the message for the body. Then you await the `SendMessageAsync()` method and finally close the connection with the `CloseAsync()` method.

```csharp
var serviceBusSender = _serviceBusClient.CreateSender("testqueue");
var sendmessage = new ServiceBusMessage("Hello, World!");
await serviceBusSender.SendMessageAsync(sendmessage);
await serviceBusSender.CloseAsync();
```

## Recieving a Message from a Queue
Akin to the sender, you must first create a Reciever using the `ServiceBusClient`. Then using the `RecievedMessageAsync()` method to fetch the message, which returns the `ServiceBusReceivedMessage` type object. Then I establish that the recieved message isn't empty and then dequeue the message with the `CompleteMessageAsync()`, giving it the exact message. Finally is close the connection with the `CloseAsync()` method.

```csharp
var serviceBusReciever = _serviceBusClient.CreateReceiver("testqueue");
var recievedmessage = await serviceBusReciever.ReceiveMessageAsync();

if (recievedmessage != null)
{
  await serviceBusReciever.CompleteMessageAsync(recievedmessage);
}

await serviceBusReciever.CloseAsync();
```

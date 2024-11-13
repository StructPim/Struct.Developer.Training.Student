using Azure.Messaging.ServiceBus;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Shared.Helpers
{
    public class MessageClient
    {
        // the client that owns the connection and can be used to create senders and receivers
        ServiceBusClient client;

        // the processor that reads and processes messages from the queue
        ServiceBusReceiver reciever;

        BlobContainerClient blobContainerClient;

        public MessageClient(string? queueName, string? messageQueueConn, string? blobContainerConn)
        {           
            var clientOptions = new ServiceBusClientOptions()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            if (!string.IsNullOrEmpty(messageQueueConn))
            {
                client = new ServiceBusClient(messageQueueConn, clientOptions);

                reciever = client.CreateReceiver(queueName);
            }

            if (!string.IsNullOrEmpty(blobContainerConn))
            {
                blobContainerClient = new BlobContainerClient(blobContainerConn, queueName);
            }
        }

        public async Task<List<int>> GetMessageQueue()
        {                     
            var updates = new List<int>();
            try
            {
                while (true)
                {
                    ServiceBusReceivedMessage receivedMessage = await reciever.ReceiveMessageAsync(maxWaitTime: TimeSpan.FromSeconds(5));                    
                    
                    if (receivedMessage != null && receivedMessage.ApplicationProperties.TryGetValue("blobName", out object? blobNameReceived))
                    {
                        var blobClient = blobContainerClient.GetBlobClient((string)blobNameReceived);

                        BlobDownloadResult downloadResult = await blobClient.DownloadContentAsync();

                        var message = downloadResult.Content.ToObjectFromJson<Message>();                        
                        
                        if (message != null)
                        {
                            updates.AddRange(message?.ProductIds);
                        }

                        // Complete the message
                        await reciever.CompleteMessageAsync(receivedMessage);
                        await blobClient.DeleteAsync();
                    }
                    else
                    {
                        Console.WriteLine("No more messages to receive.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                // Additional exception handling logic can be added here
            }
            finally
            {
                await reciever.CloseAsync();
                await client.DisposeAsync();
            }

            return updates.Distinct().ToList();
        }      
    }

    public class Message
    {
        public List<int>? ProductIds { get; set; }
    }
}

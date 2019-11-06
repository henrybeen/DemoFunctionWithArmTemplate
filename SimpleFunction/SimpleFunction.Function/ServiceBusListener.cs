using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace SimpleFunction.Function
{
    public class ServiceBusListener
    {
        [FunctionName(nameof(ServiceBusListener))]
        public void Run([ServiceBusTrigger("%QueueName%", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}

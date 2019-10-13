using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TimeManagement.Streaming.Producer
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var timeProducer = new TimeProducer();

            while (true)
            {
                await timeProducer.Publish(DateTime.UtcNow.ToString("o"));
            }            

            Console.ReadKey();
        }
    }
}

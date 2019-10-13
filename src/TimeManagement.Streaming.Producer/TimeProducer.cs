using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimeManagement.Streaming.Producer
{
    public class TimeProducer : ITimeProducer, IDisposable
    {
        private IProducer<Null, string> producer;

        public TimeProducer()
        {
            var config = new ProducerConfig { BootstrapServers = "kafka:9092" };
            producer = new ProducerBuilder<Null, string>(config).Build();
        }


        public async Task Publish(string @event)
        {
            try
            {
                var dr = await producer.ProduceAsync("time", new Message<Null, string> { Value = @event });
                Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }

        public void Dispose()
        {
            producer.Dispose();
        }
    }
}

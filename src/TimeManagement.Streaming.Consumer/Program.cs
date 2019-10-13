using System;

namespace TimeManagement.Streaming.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var bookConsumer = new TimeConsumer();
            bookConsumer.Listen(Console.WriteLine);
        }
    }
}

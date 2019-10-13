using System;

namespace TimeManagement.Streaming.Consumer
{
    public interface ITimeConsumer
    {
        void Listen(Action<string> message);
    }
}

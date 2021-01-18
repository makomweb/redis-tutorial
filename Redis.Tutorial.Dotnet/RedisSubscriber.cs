using StackExchange.Redis;
using System;

namespace Redis.Tutorial.Dotnet
{
    public class RedisSubscriber
    {
        readonly ISubscriber _sub;
        private readonly string _channel;

        public RedisSubscriber(ConnectionMultiplexer redis, string channel)
        {
            _sub = redis.GetSubscriber();
            _channel = channel;
        }

        public void Subscribe(Action<ChannelMessage> onMessage)
        {
            _sub.Subscribe(_channel).OnMessage(onMessage);            
        }
    }
}

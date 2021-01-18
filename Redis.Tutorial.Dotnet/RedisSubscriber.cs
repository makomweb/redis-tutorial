using StackExchange.Redis;
using System;

namespace Redis.Tutorial.Dotnet
{
    public class RedisSubscriber
    {
        readonly ISubscriber _sub;

        public RedisSubscriber(ConnectionMultiplexer redis)
        {
            _sub = redis.GetSubscriber();
        }

        public void Subscribe(string channel, Action<ChannelMessage> onMessage)
        {
            _sub.Subscribe(channel).OnMessage(onMessage);            
        }
    }
}

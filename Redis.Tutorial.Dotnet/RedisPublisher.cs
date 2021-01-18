using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisPublisher
    {
        readonly ISubscriber _sub;

        public RedisPublisher(ConnectionMultiplexer redis)
        {
            _sub = redis.GetSubscriber();
        }

        public void Publish(string channel, string message)
        {
            _sub.Publish(channel, message);
        }
    }
}

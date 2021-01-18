using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisPublisher
    {
        readonly ISubscriber _sub;
        private readonly string _channel;

        public RedisPublisher(ConnectionMultiplexer redis, string channel)
        {
            _sub = redis.GetSubscriber();
            _channel = channel;
        }

        public void Publish(string message)
        {
            _sub.Publish(_channel, message);
        }
    }
}

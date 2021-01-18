using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisWriter
    {
        readonly IDatabase _db;

        public RedisWriter(ConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public void Store<T>(string key, T value)
        {
            _db.StringSet(key, value.AsJson());
        }
    }
}

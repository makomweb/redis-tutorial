using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisWriter
    {
        readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        readonly IDatabase _db;

        public RedisWriter()
        {
            _db = _redis.GetDatabase();
        }

        public void Store<T>(string key, T value)
        {
            _db.StringSet(key, value.AsJson());
        }
    }
}

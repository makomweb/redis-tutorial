using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisReader
    {
        readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        readonly IDatabase _db;

        public RedisReader()
        {
            _db = _redis.GetDatabase();
        }

        public dynamic Read(string key)
        {
            var json = _db.StringGet(key);
            return JsonDecoder.Deserialize(json);
        }
    }
}

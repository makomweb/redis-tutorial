using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet
{
    public class RedisReader
    {
        readonly IDatabase _db;

        public RedisReader(ConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public dynamic Read(string key)
        {
            var json = _db.StringGet(key);
            return JsonDecoder.Deserialize(json);
        }
    }
}

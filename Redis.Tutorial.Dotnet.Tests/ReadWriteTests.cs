using NUnit.Framework;
using StackExchange.Redis;

namespace Redis.Tutorial.Dotnet.Tests
{
    public class ReadWriteTests
    {
        readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        const string KEY = "my-key";

        [SetUp]
        public void Setup()
        {
            var writer = new RedisWriter(_redis);
            writer.Store(KEY, "test");
        }

        [Test]
        public void Reading_value_should_succeed()
        {
            var reader = new RedisReader(_redis);
            var value = reader.Read(KEY);
            Assert.AreEqual("test", value);
        }
    }
}
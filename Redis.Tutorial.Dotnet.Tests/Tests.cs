using NUnit.Framework;

namespace Redis.Tutorial.Dotnet.Tests
{
    public class Tests
    {
        const string KEY = "my-key";

        [SetUp]
        public void Setup()
        {
            var writer = new RedisWriter();
            writer.Store(KEY, "test");
        }

        [Test]
        public void Reading_value_should_succeed()
        {
            var reader = new RedisReader();
            var value = reader.Read(KEY);
            Assert.AreEqual("test", value);
        }
    }
}
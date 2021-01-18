using NUnit.Framework;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Redis.Tutorial.Dotnet.Tests
{
    public class PubSubTests
    {
        readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect("localhost");
        Fixture _fixture;

        class Fixture
        {
            const string CHANNEL_NAME = "my-messages";
            readonly RedisSubscriber _subscriber;
            readonly RedisPublisher _publisher;

            public Fixture(ConnectionMultiplexer redis)
            {
                _subscriber = new RedisSubscriber(redis);
                _publisher = new RedisPublisher(redis);
            }

            internal void Subscribe(Action<string> onMessage)
            {
                var action = new Action<ChannelMessage>(msg => 
                    onMessage(msg.Message));

                _subscriber.Subscribe(CHANNEL_NAME, action);
            }

            internal void Publish(string message)
            {
                _publisher.Publish(CHANNEL_NAME, message);
            }
        }

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture(_redis);
        }

        [Test]
        public async Task Using_pub_sub_should_succeed()
        {
            string received = null;

            _fixture.Subscribe(msg => received = msg);
            _fixture.Publish("payload");

            await TaskUtils.WaitWhile(() => received == null);

            Assert.AreEqual("payload", received, "We should have received a message!");
        }

        [Test]
        public async Task Receiving_2_messages_should_succeed()
        {
            var received = 0;

            _fixture.Subscribe(_ => received++);
            _fixture.Publish("Message 1");
            _fixture.Publish("Message 2");

            await TaskUtils.WaitUntil(() => received == 2);

            Assert.AreEqual(2, received, "We should have received 2 messages!");
        }
    }
}
using StackExchange.Redis;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace Redis.Tutorial.Dotnet
{
    public class RedisEventSubscriber
    {
        readonly ISubscriber _sub;
        private readonly string _channel;

        public RedisEventSubscriber(ConnectionMultiplexer redis, string channel)
        {
            _sub = redis.GetSubscriber();
            _channel = channel;
        }

        public IObservable<ChannelMessage> Events
        {
            get
            {
                var subscription = _sub.Subscribe(_channel);

                var observable = Observable.Create<ChannelMessage>(observer =>
                {
                    subscription.OnMessage(msg =>
                    {
                        observer.OnNext(msg);
                        observer.OnCompleted();
                    });
                    return Disposable.Empty;
                });

                return observable;
            }
        }
    }
}

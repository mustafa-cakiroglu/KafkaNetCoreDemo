using System.Threading.Tasks;
using DotNetCore.CAP;
using Kafka.Domain.Common.Interfaces;

namespace Kafka.Domain.Common
{
    public class EventManager : IEventManager
    {
        private readonly ICapPublisher _bus;

        public EventManager(ICapPublisher bus)
        {
            _bus = bus;
        }

        public void Publish<T>(string name, T @event)
        {
            _bus.Publish(name, @event);
        }

        public Task PublishAsync<T>(string name, T @event)
        {
            return _bus.PublishAsync(name, @event);
        }
    }
}

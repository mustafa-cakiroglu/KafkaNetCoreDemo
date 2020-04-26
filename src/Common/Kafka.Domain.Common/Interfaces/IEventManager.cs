using System.Threading.Tasks;

namespace Kafka.Domain.Common.Interfaces
{
    public interface IEventManager
    {
        void Publish<T>(string name, T @event);
        Task PublishAsync<T>(string name, T @event);
    }
}

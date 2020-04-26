using System.Threading.Tasks;
using KafkaWebProducer.Models;

namespace KafkaWebProducer.Domain.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
    }
}

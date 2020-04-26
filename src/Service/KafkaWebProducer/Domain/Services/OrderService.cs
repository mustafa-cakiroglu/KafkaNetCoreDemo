using System;
using System.Threading.Tasks;
using Kafka.Domain.Common.Events;
using Kafka.Domain.Common.Interfaces;
using KafkaWebProducer.Domain.Interfaces;
using KafkaWebProducer.Models;

namespace KafkaWebProducer.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IEventManager _bus;
        public OrderService(IEventManager bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }
        public async Task CreateOrder(Order order)
        {
            await _bus
                .PublishAsync(
                    nameof(OrderCreatedEvent),
                    new OrderCreatedEvent
                    {
                        Id = order.Id,
                        OrderDate = order.OrderDate
                    })
                .ConfigureAwait(false);
        }
    }
}

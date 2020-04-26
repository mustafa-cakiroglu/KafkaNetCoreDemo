using System;

namespace Kafka.Domain.Common.Events
{
    public class OrderCreatedEvent : Event
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

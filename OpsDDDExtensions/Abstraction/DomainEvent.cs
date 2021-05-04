using OpsDDDExtensions.Interfaces;
using System;

namespace OpsDDDExtensions.Abstraction
{
    /// <summary>
    /// Base domain event class
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid AggregateId { get; }
        public DateTimeOffset OccurredAt { get; } = DateTime.Now;
        public int Version { get; }
        protected DomainEvent() { }
        protected DomainEvent(Guid aggregateId, int version)
        {
            AggregateId = aggregateId;
            Version = version;
        }
    }
}

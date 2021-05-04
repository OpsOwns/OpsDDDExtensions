using System;

namespace OpsDDDExtensions.Interfaces
{
    public interface IDomainEvent
    {
        public DateTimeOffset OccurredAt { get; }
    }
}
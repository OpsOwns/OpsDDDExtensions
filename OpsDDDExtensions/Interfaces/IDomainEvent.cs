using System;

namespace OpsDDDExtensions.Interfaces
{
    /// <summary>
    /// Marker interface
    /// </summary>
    public interface IDomainEvent
    {
        public DateTimeOffset OccurredAt { get; }
    }
}
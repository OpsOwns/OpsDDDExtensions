using OpsDDDExtensions.Interfaces;
using ReflectionMagic;
using System.Collections.Generic;
using System.Linq;

namespace OpsDDDExtensions.Abstraction
{
    public abstract class AggregateRoot : Entity
    {
        public int Version { get; protected set; }
        private State State { get; set; } = State.Created;
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList().AsReadOnly();
        private readonly List<IDomainEvent> _domainEvents = new();
        public bool IsAggregateDeleted => State == State.Deleted;
        protected AggregateRoot() { }
        protected AggregateRoot(Identity identity) : base(identity) { }
        public void LoadFromHistory(IEnumerable<IDomainEvent> events)
        {
            var domainEvents = events as IDomainEvent[] ?? events.ToArray();
            foreach (var @event in domainEvents)
            {
                ApplyEvent(@event, false);
            }
        }
        protected void AddEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
        private void ApplyEvent(IDomainEvent domainEvent, bool isNew)
        {
            this.AsDynamic().Apply(domainEvent);
            if (isNew)
                _domainEvents.Add(domainEvent);
        }
        public void MarkChangesAsCommitted() => _domainEvents.Clear();
        protected void MarkAggregateAsDeleted() => State = State.Deleted;
    }
}
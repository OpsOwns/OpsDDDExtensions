namespace OpsDDDExtensions.Abstraction
{
    public abstract class Entity
    {
        public Identity Id { get; protected set; }
        protected Entity() { }
        protected Entity(Identity id) => Id = id;
        public override bool Equals(object obj)
        {
            if (obj is not Entity other)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return Id.Equals(other.Id);
        }
        public static bool operator !=(Entity value1, Entity value2) => !(value1 == value2);
        public static bool operator ==(Entity value1, Entity value2) =>
            value1 is null && value2 is null ||
            value1 is not null && value2 is not null && value1.Equals(value2);
        public override int GetHashCode() => GetType().GetHashCode();
    }
}

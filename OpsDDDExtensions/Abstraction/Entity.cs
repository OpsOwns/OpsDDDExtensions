﻿using OpsDDDExtensions.Abstraction.Identity;
using OpsDDDExtensions.Interfaces;

namespace OpsDDDExtensions.Abstraction
{
    /// <summary>
    /// Base entity class with id as guid
    /// </summary>
    public abstract class Entity : Entity<IdentityGuid>
    {
        protected Entity(IdentityGuid id) : base(id) { }
    }
    /// <summary>
    /// Base entity class where id could be custom
    /// </summary>
    /// <typeparam name="TId">Id class</typeparam>
    public abstract class Entity<TId> where TId : IIdentity
    {
        public TId Id { get; protected set; }
        protected Entity() { }
        protected Entity(TId id) => Id = id;
        public override bool Equals(object obj)
        {
            if (obj is not Entity<TId> other)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (GetType() != other.GetType())
                return false;
            return Id.Equals(other.Id);
        }
        public static bool operator !=(Entity<TId> value1, Entity<TId> value2) => !(value1 == value2);
        public static bool operator ==(Entity<TId> value1, Entity<TId> value2) =>
            value1 is null && value2 is null ||
            value1 is not null && value2 is not null && value1.Equals(value2);
        public override int GetHashCode() => GetType().GetHashCode();
    }
}

using System;

namespace OpsDDDExtensions.Abstraction.DDD.Identity
{
    /// <summary>
    /// Default Identity class as Guid
    /// </summary>
    public record IdentityGuid : BaseIdentity<Guid>
    {
        public IdentityGuid(Guid value = default) : base(value == Guid.Empty ? Guid.NewGuid() : value) { }
    }
}
using System;

namespace OpsDDDExtensions.Abstraction.Identity
{
    /// <summary>
    /// Default Identity class as ulid
    /// </summary>
    public abstract record IdentityUlid : BaseIdentity<Ulid>
    {
        public IdentityUlid(Ulid value = default) : base(value == Ulid.Empty ? Ulid.NewUlid() : value)
        {
        }
    }
}

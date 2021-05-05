using OpsDDDExtensions.Abstraction.DDD;
using OpsDDDExtensions.Abstraction.DDD.Identity;
using System;

namespace OpsDDDExtensions.Tests.FakeData
{
    public record GrapeId : BaseIdentity<Ulid>
    {
        public GrapeId(Ulid value) : base(value)
        {
        }
    }
    public class Grape : Entity<GrapeId>
    {
        public Grape(GrapeId id) : base(id)
        {
        }
    }
}

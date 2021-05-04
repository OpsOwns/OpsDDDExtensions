using OpsDDDExtensions.Abstraction;
using OpsDDDExtensions.Abstraction.Identity;
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

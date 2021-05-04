using OpsDDDExtensions.Abstraction.Identity;
using OpsDDDExtensions.Tests.FakeData;
using System;
using Xunit;

namespace OpsDDDExtensions.Tests
{
    public class EntityTests
    {
        [Fact]
        public void Create_Entity_Base_Success()
        {
            var person = new Person(new IdentityGuid());
            Assert.NotNull(person);
        }
        [Fact]
        public void Create_Entity_Custom_Base_Success()
        {
            var person = new Grape(new GrapeId(Ulid.NewUlid()));
            Assert.NotNull(person);
        }
    }
}

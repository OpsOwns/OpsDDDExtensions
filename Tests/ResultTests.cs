using OpsDDDExtensions.Tests.FakeData;
using Xunit;

namespace OpsDDDExtensions.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_returns_fail()
        {
            var person = Person.Create(null, "abc");
            Assert.True(person.IsError);
            Assert.Equal("invalid name", person.Error.Message);
        }
    }
}

using OpsDDDExtensions.Tests.FakeData;
using Xunit;

namespace OpsDDDExtensions.Tests
{
    public class ResultTests
    {
        [Fact]
        public void Result_returns_fail()
        {
            var result = FullName.Create(null, "Test");
            Assert.True(result.IsError);
            Assert.Equal("invalid name", result.Error.Message);
        }
    }
}

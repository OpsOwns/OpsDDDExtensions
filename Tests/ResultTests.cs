using OpsDDDExtensions.Extensions;
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
            Assert.True(result.Failure);
            Assert.Equal("invalid name", result.Error.Message);
        }
        [Fact]
        public void Result_Returns_Ok()
        {
            var result = FullName.Create("Test", "Test");
            Assert.False(result.Failure);
        }

        [Fact]
        public void Result_Then_Failure()
        {
            var result = FullName.Create("Test", "Test").Then(z => AgeGen.Create(12))
                .Then(z => FullName.Create(null, null));
            Assert.True(result.Failure);
            Assert.Equal("invalid age", result.Error.Message);
        }

        [Fact]
        public void Result_Then_Failure_With_Third_Part()
        {
            var result = FullName.Create("Test", "Test").Then(z => AgeGen.Create(32))
                .Then(z => FullName.Create(null, null));
            Assert.True(result.Failure);
            Assert.Equal("invalid name", result.Error.Message);
        }

        [Fact]
        public void Result_Combine_Errors()
        {
            var value1 = FullName.Create("test", "gg");
            var value2 = AgeGen.Create(12);
            var value3 = FullName.Create(null, "test");
            var result = Result.Combine(value1, value2, value3);
            Assert.True(result.Failure);
            Assert.Equal("invalid age", result.Error.Message);
        }

    }
}

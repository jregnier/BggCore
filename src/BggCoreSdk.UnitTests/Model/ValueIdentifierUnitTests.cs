using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class ValueIdentifierUnitTests
    {
        [Fact]
        public void ToString_Returns_Value()
        {
            const string VALUE = "this is a value";

            // arrange
            var dto = new ValueIdentifier()
            {
                Value = VALUE
            };

            // act
            var result = dto.ToString();

            // assert
            Assert.Equal(VALUE, result);
        }
    }
}
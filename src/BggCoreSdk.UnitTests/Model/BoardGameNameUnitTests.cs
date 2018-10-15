using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class BoardGameNameUnitTests
    {
        [Fact]
        public void ToString_Returns_Value()
        {
            const string VALUE = "this is a name";

            // arrange
            var dto = new BoardGameName()
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
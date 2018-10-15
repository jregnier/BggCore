using BggCoreSdk.Dto;
using Xunit;

namespace BggCoreSdk.UnitTests.Dto
{
    public class BoardGameNameDtoUnitTests
    {
        [Fact]
        public void ToString_Returns_Value()
        {
            const string VALUE = "this is a name";

            // arrange
            var dto = new BoardGameNameDto()
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
using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class BoardGameSearchUnitTests
    {
        [Fact]
        public void ToString_Returns_Name()
        {
            const string NAME = "this is a name";

            // arrange
            var dto = new BoardGameSearch()
            {
                Name = new BoardGameName() { Value = NAME }
            };

            // act
            var result = dto.ToString();

            // assert
            Assert.Equal(NAME, result);
        }
    }
}
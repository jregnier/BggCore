using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class BoardGamePollUnitTests
    {
        [Fact]
        public void ToString_Returns_Name()
        {
            const string NAME = "this is a name";

            // arrange
            var dto = new BoardGamePoll()
            {
                Name = NAME
            };

            // act
            var result = dto.ToString();

            // assert
            Assert.Equal(NAME, result);
        }
    }
}
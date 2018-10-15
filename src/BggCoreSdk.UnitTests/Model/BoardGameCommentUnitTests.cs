using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class BoardGameCommentUnitTests
    {
        [Fact]
        public void ToString_Returns_Value()
        {
            const string VALUE = "this is a comment";

            // arrange
            var dto = new BoardGameComment()
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
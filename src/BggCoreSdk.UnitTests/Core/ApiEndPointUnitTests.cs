using BggCoreSdk.Core;
using Xunit;

namespace BggCoreSdk.UnitTests.Core
{
    public class ApiEndPointUnitTests
    {
        [Fact]
        public void List_Returns_Correct_Items()
        {
            // arrange
            var expected = new[]
            {
                ApiEndPoint.Search,
                ApiEndPoint.BoardGame,
                ApiEndPoint.Collection,
                ApiEndPoint.Thread,
                ApiEndPoint.GeekList
            };

            // act
            var result = ApiEndPoint.List();

            // assert
            Assert.Equal(expected, result);
        }
    }
}
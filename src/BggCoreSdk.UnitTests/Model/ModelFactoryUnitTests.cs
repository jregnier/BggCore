using System.Linq;
using BggCoreSdk.Dto;
using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class ModelFactoryUnitTests
    {
        [Fact]
        public void CreateBoardGameSearch_Returns_Object()
        {
            // arrange
            var dtoObject = DataProvider.GetBoardGameSearchResults().First();
            var factory = new ModelFactory();

            // act
            var result = factory.CreateBoardGameSearch(dtoObject);

            // assert
            Assert.NotNull(result);
            Assert.Equal(dtoObject.Id, result.Id.ToString());
            Assert.Equal(dtoObject.Names[0].Value, result.Name.Value);
            Assert.Equal(dtoObject.YearPublished, result.YearPublished.ToString());
        }

        [Fact]
        public void CreateBoardGameSearch_Returns_Null()
        {
            // arrange
            var factory = new ModelFactory();

            // act
            var result = factory.CreateBoardGameSearch(null);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateBoardGame_Returns_Object()
        {
            // arrange
            var dtoObject = DataProvider.GetBoardGameResults().First();
            var factory = new ModelFactory();

            // act
            var result = factory.CreateBoardGame(dtoObject);

            // assert
            Assert.NotNull(result);
            Assert.Equal(dtoObject.Id, result.Id.ToString());
            Assert.Equal(dtoObject.YearPublished, result.YearPublished.ToString());
            Assert.Equal(dtoObject.MinPlayers, result.MinPlayers.ToString());
            Assert.Equal(dtoObject.MaxPlayers, result.MaxPlayers.ToString());
        }

        [Fact]
        public void CreateBoardGame_Returns_Null()
        {
            // arrange
            var factory = new ModelFactory();

            // act
            var result = factory.CreateBoardGame(null);

            // assert
            Assert.Null(result);
        }
    }
}
using BggCoreSdk.Dto;
using BggCoreSdk.Model;
using Xunit;

namespace BggCoreSdk.UnitTests.Model
{
    public class ModelFactoryUnitTests
    {
        [Fact]
        public void Create_BoardGameSearch_Returns_Object()
        {
            // arrange
            var dtoObject = new BoardGameSearchDto()
            {
                Id = 1,
                Name = new BoardGameNameDto() { Value = "fake name" },
                YearPublished = 1990
            };
            var factory = new ModelFactory();

            // act
            var result = factory.Create(dtoObject);

            // assert
            Assert.NotNull(result);
            Assert.Equal(dtoObject.Id, result.Id);
            Assert.Equal(dtoObject.Name.Value, result.Name.Value);
            Assert.Equal(dtoObject.YearPublished, result.YearPublished);
        }

                [Fact]
        public void Create_BoardGameSearch_Returns_Null()
        {
            // arrange
            var factory = new ModelFactory();

            // act
            var result = factory.Create(null);

            // assert
            Assert.Null(result);
        }
    }
}
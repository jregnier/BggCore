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
            var dtoObject = new BoardGameDto()
            {
                Id = "1",
                Names = new[] { new BoardGameNameDto() { Value = "fake name" } },
                YearPublished = "1990"
            };
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
            var dtoObject = new BoardGameDto()
            {
                Id = "1",
                YearPublished = "1990",
                MinPlayers = "5",
                MaxPlayers = "10",
                PlayingTime = "15",
                MinPlayTime = "5",
                MaxPlayTime = "20",
                Age = "25",
                Names = new[]
                {
                    new BoardGameNameDto { Value = "fake name1", IsPrimary = "true", SortIndex = "1" },
                    new BoardGameNameDto { Value = "fake name2", IsPrimary = "false", SortIndex = "2" }
                },
                Description = "this is a description",
                Thumbnail = "https://path/to/thumbnail.jpeg",
                Image = "https://path/to/image.jpeg",
                BoardGameSubdomains = new[]
                {
                    new ValueIdentifierDto { Id = "1", Value = "value1" },
                    new ValueIdentifierDto { Id = "2", Value = "value2" }
                },
                BoardGamePublishers = new[]
                {
                    new ValueIdentifierDto { Id = "3", Value = "value3" },
                    new ValueIdentifierDto { Id = "4", Value = "value4" }
                },
                BoardGameVersions = new[]
                {
                    new ValueIdentifierDto { Id = "5", Value = "value5" },
                    new ValueIdentifierDto { Id = "6", Value = "value6" }
                },
                BoardGameCategories = new[]
                {
                    new ValueIdentifierDto { Id = "7", Value = "value7" },
                    new ValueIdentifierDto { Id = "8", Value = "value8" }
                },
                BoardgameArtists = new[]
                {
                    new ValueIdentifierDto { Id = "9", Value = "value9" },
                    new ValueIdentifierDto { Id = "10", Value = "value10" }
                },
                BoardGameExpansions = new[]
                {
                    new ValueIdentifierDto { Id = "11", Value = "value11" },
                    new ValueIdentifierDto { Id = "12", Value = "value12" }
                },
                BoardGameDesigners = new[]
                {
                    new ValueIdentifierDto { Id = "13", Value = "value13" },
                    new ValueIdentifierDto { Id = "14", Value = "value14" }
                },
                BoardGameFamilies = new[]
                {
                    new ValueIdentifierDto { Id = "15", Value = "value15" },
                    new ValueIdentifierDto { Id = "16", Value = "value16" }
                },
                BoardGameAccessories = new[]
                {
                    new ValueIdentifierDto { Id = "17", Value = "value17" },
                    new ValueIdentifierDto { Id = "18", Value = "value18" }
                },
                VideogameBg = new[]
                {
                    new ValueIdentifierDto { Id = "19", Value = "value19" },
                    new ValueIdentifierDto { Id = "20", Value = "value20" }
                },
                Polls = new[]
                {
                    new BoardGamePollDto
                    {
                        Name = "suggested_numplayers",
                        Title = "User Suggested Number of Players",
                        TotalVotes = "100",
                        Results = new[]
                        {
                            new BoardGamePollResultDto { Value = "value1", NumVotes = "5" },
                            new BoardGamePollResultDto { Value = "value2", NumVotes = "10" }
                        }
                    }
                }
            };
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
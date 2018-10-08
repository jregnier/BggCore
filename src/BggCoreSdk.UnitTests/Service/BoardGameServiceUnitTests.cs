using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Dto;
using BggCoreSdk.Model;
using BggCoreSdk.Service;
using Moq;
using Xunit;

namespace BggCoreSdk.UnitTests.Service
{
    public class BoardGameServiceUnitTests
    {
        [Fact]
        public void Create_Not_Null()
        {
            // arrange, act
            var service = BoardGameService.Create();

            // assert
            Assert.NotNull(service);
        }

        [Fact]
        public async Task SearchAsync_Failure()
        {
            // arrange
            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.BuildUri(ApiEndPoint.Search, It.IsAny<NameValueCollection>()))
                .Throws(new Exception("my error"));
            var modelFactory = new Mock<IModelFactory>(MockBehavior.Strict);
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory.Object);

            // act
            var result = await service.SearchAsync();

            // assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task SearchAsync_Returns_results()
        {
            // arrange
            var boardGamesList = new BoardGameListDto()
            {
                BoardGames = new List<BoardGameDto>()
                {
                    new BoardGameDto()
                    {
                        Id = "1",
                        Names = new[] { new BoardGameNameDto { Value = "name1" } },
                        YearPublished = "1999"
                    },
                    new BoardGameDto()
                    {
                        Id = "2",
                        Names = new[] { new BoardGameNameDto() { Value = "name2" } },
                        YearPublished = "1999"
                    }
                }
            };

            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.BuildUri(ApiEndPoint.Search, It.IsAny<NameValueCollection>()))
                .Returns(new Uri("http://fake/url"));
            apiProviderMock
                .Setup(x => x.CallWebServiceGetAsync<BoardGameListDto>(It.IsAny<Uri>()))
                .ReturnsAsync(boardGamesList);
            var modelFactory = new ModelFactory();
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory);

            // act
            var result = await service.SearchAsync();

            // assert
            Assert.True(result.IsSuccess);
            Assert.Equal(boardGamesList.BoardGames.Count, result.Value.Count);
        }

        [Fact]
        public async Task FindAsync_Failure()
        {
            // arrange
            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.BuildUri(ApiEndPoint.Search, It.IsAny<NameValueCollection>()))
                .Throws(new Exception("my error"));
            var modelFactory = new Mock<IModelFactory>(MockBehavior.Strict);
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory.Object);

            // act
            var result = await service.FindAsync(new[] { "5", "10" });

            // assert
            Assert.False(result.IsSuccess);
        }

        [Fact]
        public async Task FindAsync_Returns_results()
        {
            // arrange
            var boardGamesList = new BoardGameListDto()
            {
                BoardGames = new List<BoardGameDto>()
                {
                    new BoardGameDto()
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
                    }
                }
            };

            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.BuildUri(ApiEndPoint.Search, It.IsAny<NameValueCollection>()))
                .Returns(new Uri("http://fake/url"));
            apiProviderMock
                .Setup(x => x.CallWebServiceGetAsync<BoardGameListDto>(It.IsAny<Uri>()))
                .ReturnsAsync(boardGamesList);
            var modelFactory = new ModelFactory();
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory);

            // act
            var result = await service.SearchAsync();

            // assert
            Assert.True(result.IsSuccess);
            Assert.Equal(boardGamesList.BoardGames.Count, result.Value.Count);
        }

        [Fact]
        public void Where_Null_Property_Throws()
        {
            // arrange
            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            var modelFactory = new Mock<IModelFactory>(MockBehavior.Strict);
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory.Object);

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => service.Where(null, "value1"));
            Assert.Equal("property", result.ParamName);
        }

        [Fact]
        public void Where_Null_Value_Throws()
        {
            // arrange
            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            var modelFactory = new Mock<IModelFactory>(MockBehavior.Strict);
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory.Object);

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => service.Where(x => x.Search, null));
            Assert.Equal("value", result.ParamName);
        }

        [Fact]
        public void Where_Adds_Parameter()
        {
            // arrange
            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.GetQueryPropertyName<BoardGameSearchQueryParameters>(It.IsAny<string>()))
                .Returns("search");
            var modelFactory = new Mock<IModelFactory>(MockBehavior.Strict);
            var service = BoardGameService.Create(apiProviderMock.Object, modelFactory.Object);

            // act
            var result = service.Where(x => x.Search, "value1");

            Assert.NotNull(result);
            Assert.Equal(service, result);
        }
    }
}
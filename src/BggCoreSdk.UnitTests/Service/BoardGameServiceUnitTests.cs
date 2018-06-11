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
            var boardGamesList = new BoardGameSearchListDto()
            {
                BoardGames = new List<BoardGameSearchDto>()
                {
                    new BoardGameSearchDto()
                    {
                        Id = 1,
                        Name = "name1",
                        YearPublished = 1999
                    },
                    new BoardGameSearchDto()
                    {
                        Id = 2,
                        Name = "name2",
                        YearPublished = 1999
                    }
                }
            };

            var apiProviderMock = new Mock<IApiProvider>(MockBehavior.Strict);
            apiProviderMock
                .Setup(x => x.BuildUri(ApiEndPoint.Search, It.IsAny<NameValueCollection>()))
                .Returns(new Uri("http://fake/url"));
            apiProviderMock
                .Setup(x => x.CallWebServiceGetAsync<BoardGameSearchListDto>(It.IsAny<Uri>()))
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
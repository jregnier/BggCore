using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using BggCoreSdk.Core;
using BggCoreSdk.Service;
using Moq;
using Xunit;

namespace BggCoreSdk.UnitTests.Service
{
    public class ApiProviderUnitTests
    {
        [Fact]
        public void BuildUri_Null_Parameters_Throws()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => provider.BuildUri(ApiEndPoint.Search, parameters: null));
            Assert.Equal("parameters", result.ParamName);
        }

        [Fact]
        public void BuildUri_With_Paramters()
        {
            // arrange
            const string EXPECTED_URL = "http://www.boardgamegeek.com/xmlapi/search?property1=value1&property2=value2&property3=value3";
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            var parametersCollection = new NameValueCollection()
            {
                { "property1", "value1" },
                { "property2", "value2" },
                { "property3", "value3" }
            };

            // act
            var result = provider.BuildUri(ApiEndPoint.Search, parametersCollection);

            // assert
            Assert.Equal(EXPECTED_URL, result.ToString());
        }

        [Fact]
        public void BuildUri_No_Paramters()
        {
            // arrange
            const string EXPECTED_URL = "http://www.boardgamegeek.com/xmlapi/search";
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            var parametersCollection = new NameValueCollection();

            // act
            var result = provider.BuildUri(ApiEndPoint.Search, parametersCollection);

            // assert
            Assert.Equal(EXPECTED_URL, result.ToString());
        }

        [Fact]
        public void BuildUri_Null_ParameterValue_Throws()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => provider.BuildUri(ApiEndPoint.Search, parameterValue: null));
            Assert.Equal("parameterValue", result.ParamName);
        }

        [Fact]
        public void BuildUri_With_ParamterValue()
        {
            // arrange
            const string PARAMETER_VALUE = "value1";
            const string EXPECTED_URL = "http://www.boardgamegeek.com/search/value1";
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act
            var result = provider.BuildUri(ApiEndPoint.Search, PARAMETER_VALUE);

            // assert
            Assert.Equal(EXPECTED_URL, result.ToString());
        }

        [Fact]
        public void GetQueryPropertyName_Null_PropertyName_Throws()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() =>
                provider.GetQueryPropertyName<QueryPropertyTestObject>(null));
            Assert.Equal("propertyName", result.ParamName);
        }

        [Fact]
        public void GetQueryPropertyName_No_Property()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act
            var result = provider.GetQueryPropertyName<QueryPropertyTestObject>("fakeProperty");

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void GetQueryPropertyName_Exist()
        {
            // arrange
            const string QUERY_PROPERTY_NAME = "queryproperty2";
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act
            var result = provider.GetQueryPropertyName<QueryPropertyTestObject>("Property2");

            // assert
            Assert.Equal(QUERY_PROPERTY_NAME, result);
        }

        [Fact]
        public void GetQueryPropertyName_No_Attribute()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act
            var result = provider.GetQueryPropertyName<QueryPropertyTestObject>("Property1");

            // assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CallWebServiceGetAsync_Null_URL_Throws()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            var provider = new ApiProvider(adapterMock.Object);

            // act, assert
            var result = await Assert.ThrowsAsync<ArgumentNullException>(() =>
                provider.CallWebServiceGetAsync<BggResponseTestObject>(null));
            Assert.Equal("requestUri", result.ParamName);
        }

        [Fact]
        public async Task CallWebServiceGetAsync_Returns()
        {
            // arrange
            var adapterMock = new Mock<IBggApiServiceAdapter>(MockBehavior.Strict);
            adapterMock
                .Setup(x => x.WebGetAsync<BggResponseTestObject>(It.IsAny<Uri>()))
                .ReturnsAsync(new BggResponseTestObject());
            var provider = new ApiProvider(adapterMock.Object);

            // act
            var result = await provider.CallWebServiceGetAsync<BggResponseTestObject>(new Uri("http://fake/url"));

            // assert
            Assert.NotNull(result);
        }
    }
}
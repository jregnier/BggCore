using BggCoreSdk.Service;
using Xunit;

namespace BggCoreSdk.UnitTests.Service
{
    public class QueryPropertyAttributeUnitTests
    {
        [Fact]
        public void Ctor_Property_Set()
        {
            // arrange
            const string PROPERTY_NAME = "myProperty";
            var property = new QueryPropertyAttribute(PROPERTY_NAME);

            // act
            var result = property.PropertyName;

            // assert
            Assert.Equal(PROPERTY_NAME, result);
        }
    }
}
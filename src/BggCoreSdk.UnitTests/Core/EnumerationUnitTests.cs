using System;
using System.Linq;
using Xunit;
using BggCoreSdk.Core;

namespace BggCoreSdk.UnitTests.Core
{
    public class EnumerationUnitTests
    {
        [Fact]
        public void GetAll_Success()
        {
            // arrange, act
            var result = Enumeration.GetAll<EnumerationTestObject>();

            //assert
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void CompareTo_Success()
        {
            // arrange
            var testObject1 = EnumerationTestObject.Option1;
            var testObject2 = EnumerationTestObject.Option1;

            // act
            var result = testObject1.CompareTo(testObject2);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Equals_True()
        {
            // arrange
            var testObject1 = EnumerationTestObject.Option1;
            var testObject2 = EnumerationTestObject.Option1;

            // act
            var result = testObject1.Equals(testObject2);

            //assert
            Assert.True(result);
        }

        [Fact]
        public void Equals_Not_Same_Type()
        {
            // arrange
            var testObject1 = EnumerationTestObject.Option1;
            var testObject2 = EnumerationTestObject.Option2;

            // act
            var result = testObject1.Equals(testObject2);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void Equals_Not_Enumeration()
        {
            // arrange
            var testObject1 = EnumerationTestObject.Option1;
            var testObject2 = new Object();

            // act
            var result = testObject1.Equals(testObject2);

            //assert
            Assert.False(result);
        }

        [Fact]
        public void FromString_Success()
        {
            // arrange
            const string OPTION1 = "option1";

            // act
            var result = Enumeration.FromString<EnumerationTestObject>(OPTION1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(OPTION1, result.Name);
        }

        [Fact]
        public void FromString_ReturnsNull()
        {
            // arrange, act
            var result = Enumeration.FromString<EnumerationTestObject>("thebadman");

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void FromValue_Success()
        {
            // arrange
            const int OPTION1 = 0;

            // act
            var result = Enumeration.FromValue<EnumerationTestObject>(OPTION1);

            // assert
            Assert.NotNull(result);
            Assert.Equal(OPTION1, result.Value);
        }

        [Fact]
        public void FromValue_ReturnsNull()
        {
            // arrange, act
            var result = Enumeration.FromValue<EnumerationTestObject>(100);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void GetHashCode_Returns_Value_HashCode()
        {
            // arrange, act
            var result = EnumerationTestObject.Option1.GetHashCode();

            // assert
            Assert.Equal(EnumerationTestObject.Option1.Value.GetHashCode(), result);
        }

                [Fact]
        public void ToString_Returns_Name()
        {
            // arrange, act
            var result = EnumerationTestObject.Option1.ToString();

            // assert
            Assert.Equal(EnumerationTestObject.Option1.Name, result);
        }
    }
}

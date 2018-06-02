using System;
using Xunit;
using BggCoreSdk.Core;

namespace BggCoreSdk.UnitTests.Core
{
    public class ExceptionalUnitTests
    {
        [Fact]
        public void Failure_Create_Success()
        {
            // arrange
            var exception = new Exception("my exception");

            // act
            var result = Exceptional<string>.Failure(exception);

            // assert
            Assert.False(result.IsSuccess);
            Assert.Equal(exception, result.Exception);
        }

        [Fact]
        public void Success_Create_Success()
        {
            // arrange
            const string VALUE = "my awesome value";

            // act
            var result = Exceptional<string>.Success(VALUE);

            // assert
            Assert.True(result.IsSuccess);
            Assert.Equal(VALUE, result.Value);
        }

        [Fact]
        public void IfFailure_Throw_Exception_Null_Parameter()
        {
            // arrange
            var testObject = Exceptional<string>.Success("my value");

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => testObject.IfFailure(null));
            Assert.Equal("action", result.ParamName);
        }

        [Fact]
        public void IfFailure_Executes_Action()
        {
            // arrange
            const int EXPECTED_RESULT = 10;
            var testResult = 0;
            var testObject = Exceptional<string>.Failure(new Exception());

            // act
            testObject.IfFailure(ex => testResult = EXPECTED_RESULT);

            // assert
            Assert.Equal(EXPECTED_RESULT, testResult);
        }

        [Fact]
        public void IfSuccess_Throw_Exception_Null_Parameter()
        {
            // arrange
            var testObject = Exceptional<string>.Success("my value");

            // act, assert
            var result = Assert.Throws<ArgumentNullException>(() => testObject.IfSuccess(null));
            Assert.Equal("action", result.ParamName);
        }

        [Fact]
        public void IfSuccess_Executes_Action()
        {
            // arrange
            const int EXPECTED_RESULT = 10;
            var testResult = 0;
            var testObject = Exceptional<string>.Success("my value");

            // act
            testObject.IfSuccess(ex => testResult = EXPECTED_RESULT);

            // assert
            Assert.Equal(EXPECTED_RESULT, testResult);
        }
    }
}
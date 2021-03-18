using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cds.BusinessCustomer.Api.Tests.Unit
{
    public class ParametersHandlerTest
    {
        Mock<ILogger<ParametersHandler>> mockLogger;
        ParametersHandler paramsHandler;

        public ParametersHandlerTest()
        {
            mockLogger = new Mock<ILogger<ParametersHandler>>();
            paramsHandler = new ParametersHandler(mockLogger.Object);
        }

        [Fact]
        public void Validate_GivenValidSiret_ReturnsTrue()
        {
            // Arrange            

            // Arrange
            var actual = paramsHandler.Validate("12345678945786");

            // Assert
            Assert.True(actual.Item1);
        }

        [Fact]
        public void Validate_GivenInvalidSiret_ReturnsFalse()
        {
            // Arrange

            // Arrange
            var actual1 = paramsHandler.Validate("123456");
            var actual2 = paramsHandler.Validate("");

            // Assert
            Assert.False(actual1.Item1);
            Assert.False(actual2.Item1);
        }

        [Fact]
        public void ValidateTest_GivenValidSocialreasonAndZipcode_ReturnsTrue()
        {
            // Arrange

            // Act
            var actual = paramsHandler.Validate("122", "4152");

            // Assert
            Assert.True(actual.Item1);
        }

        [Fact]
        public void Validate_GivenNullOrEmptySocialreason_ReturnsFalse()
        {
            // Arrange

            // Act
            var actual1 = paramsHandler.Validate(null, "123456");
            var actual2 = paramsHandler.Validate("", "123456");

            // Assert
            Assert.False(actual1.Item1);
            Assert.False(actual2.Item1);
        }
        [Fact]
        public void Validate_GivenNullOrEmptyZipcode_ReturnsFalse()
        {
            // Arrange

            // Act
            var actual1 = paramsHandler.Validate("123456", null);
            var actual2 = paramsHandler.Validate("123456", "");

            // Assert
            Assert.False(actual1.Item1);
            Assert.False(actual2.Item1);
        }
    }
}

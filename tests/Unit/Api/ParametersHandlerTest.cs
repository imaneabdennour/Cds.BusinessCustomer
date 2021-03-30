using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Xunit;

namespace Cds.BusinessCustomer.Api.Tests.Unit
{
    public class ParametersHandlerTest
    {
        readonly Mock<ILogger<ParametersHandler>> mockLogger;
        readonly ParametersHandler paramsHandler;

        public ParametersHandlerTest()
        {
            mockLogger = new Mock<ILogger<ParametersHandler>>();
            paramsHandler = new ParametersHandler(mockLogger.Object);
        }

        [Fact]
        public void Validate_GivenValidSiret_ReturnsTrue()
        {
            // Arrange            

            // Act
            var actual = paramsHandler.Validate("12345678945786");

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Validate_GivenInvalidSiret_ReturnsFalse()
        {
            // Arrange

            // Act
            var actual1 = paramsHandler.Validate("123456");
            var actual2 = paramsHandler.Validate("");

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public void ValidateTest_GivenValidSocialreasonAndZipcode_ReturnsTrue()
        {
            // Arrange

            // Act
            var actual = paramsHandler.Validate("122", "4152");

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Validate_GivenNullOrEmptySocialreason_ReturnsFalse()
        {
            // Arrange

            // Act
            var actual1 = paramsHandler.Validate(null, "123456");
            var actual2 = paramsHandler.Validate("", "123456");

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }
        [Fact]
        public void Validate_GivenNullOrEmptyZipcode_ReturnsFalse()
        {
            // Arrange

            // Act
            var actual1 = paramsHandler.Validate("123456", null);
            var actual2 = paramsHandler.Validate("123456", "");

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }
    }
}

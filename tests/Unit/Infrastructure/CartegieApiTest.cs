using Cds.TestFormationDotnetcore.Infrastructure;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.IO;
using System;

namespace Cds.BusinessCustomer.Infrastructure.Tests.Unit
{
    public class CartegieApiTest
    {
        readonly CartegieConfiguration config;
        readonly Mock<IHttpClientFactory> mockFactory;

        public CartegieApiTest()
        {
            // It's easy to use a real config, instead of mocking it :
            config = new CartegieConfiguration { BaseUrl = new Uri("https://6037a3775435040017722f92.mockapi.io/api/v1/Company/")};
            mockFactory = new Mock<IHttpClientFactory>();
        }
        
            // Siret Search
     
        [Fact]
        public async Task GetInfosBySiret_GivenValidSiret_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Single");
            // object with mocked params
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosBySiret("12345678912345");

            //Assert
            Assert.NotNull(result);
            result.Name.Should().Be("UBER PARTNER SUPPORT FRANCE SAS");
        }

        [Fact]
        public async Task GetInfosBySiret_GivenNullOrEmptySiret_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosBySiret(null);
            var result2 = await cartegieAPi.GetInfosBySiret("");

            //Assert
            result1.Should().BeNull();
            result2.Should().BeNull();
        }

        [Fact]
        public async Task GetInfosBySiret_GivenInvalidSiret_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosBySiret("123");

            //Assert
            result.Should().BeNull();
        }

            // Id Search      

        [Fact]
        public async Task GetInfosById_GivenId_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Single");
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);            

            //Act
            var result = await cartegieAPi.GetInfosById("1235");

            //Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("UBER PARTNER SUPPORT FRANCE SAS");
        }

        [Fact]
        public async Task GetInfosById_GivenNullOrEmptyId_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            // object with mocked params
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosById(null);
            var result2 = await cartegieAPi.GetInfosById("");

            //Assert
            result1.Should().BeNull();
            result2.Should().BeNull();
        }

            // Multiple Search        

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParams_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosByCriteria("123", "456");

            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParamsWithNullOrEmptyZipCode_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosByCriteria("123", null);
            var result2 = await cartegieAPi.GetInfosByCriteria("123", "");

            //Assert
            result1.Should().BeEmpty();
            result2.Should().BeEmpty();
        }

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParamsWithNullOrEmptySocialReason_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(config, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosByCriteria(null, "123");
            var result2 = await cartegieAPi.GetInfosByCriteria("", "123");

            //Assert
            result1.Should().BeEmpty();
            result2.Should().BeEmpty();
        } 


        private void HttpClientConfig(string type)
        {
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = Response(type)
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);
        }

        private StringContent Response(string type)
        {
            if (type.Equals("Single"))           
                return new StringContent(File.ReadAllText("../../../SingleCartegieResponse.json"), System.Text.Encoding.UTF8, "application/json");
             
            if (type.Equals("Multiple"))
                return new StringContent(File.ReadAllText("../../../MultipleCartegieResponse.json"), System.Text.Encoding.UTF8, "application/json");

            return new StringContent(File.ReadAllText("../../../EmptyCartegieResponse.json"), System.Text.Encoding.UTF8, "application/json");
        }


    }
}

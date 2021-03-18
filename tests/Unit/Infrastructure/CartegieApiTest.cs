using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Cds.TestFormationDotnetcore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Cds.BusinessCustomer.Infrastructure.Tests.Unit
{
    public class CartegieApiTest
    {
        Mock<CartegieConfiguration> mockConfig;
        Mock<IHttpClientFactory> mockFactory;

        public CartegieApiTest()
        {
            mockConfig = new Mock<CartegieConfiguration>();
            mockFactory = new Mock<IHttpClientFactory>();
        }
        
            // Siret Search
     
        [Fact]
        public async Task GetInfosBySiret_GivenValidSiret_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Single");
            // object with mocked params
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosBySiret("12345678912345");

            //Assert
            Assert.NotNull(result);
            // valid siret is of length 14
            Assert.Equal("UBER PARTNER SUPPORT FRANCE SAS", result.Name);
        }

        [Fact]
        public async Task GetInfosBySiret_GivenNullOrEmptySiret_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosBySiret(null);
            var result2 = await cartegieAPi.GetInfosBySiret("");

            //Assert
            Assert.Null(result1);
            Assert.Null(result2);
        }

        [Fact]
        public async Task GetInfosBySiret_GivenInvalidSiret_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosBySiret("123");

            //Assert
            Assert.Null(result);
        }

            // Id Search      

        [Fact]
        public async Task GetInfosById_GivenId_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Single");
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosById("1235");

            //Assert
            Assert.NotNull(result);
            Assert.Equal("UBER PARTNER SUPPORT FRANCE SAS", result.Name);
        }

        [Fact]
        public async Task GetInfosById_GivenNullOrEmptyId_ShouldReturnNull()
        {
            //Arrange
            HttpClientConfig("Empty");
            // object with mocked params
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosById(null);
            var result2 = await cartegieAPi.GetInfosById("");

            //Assert
            Assert.Null(result1);
            Assert.Null(result2);
        }

            // Multiple Search        

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParams_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result = await cartegieAPi.GetInfosByCriteria("123", "456");

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParamsWithNullOrEmptyZipCode_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosByCriteria("123", null);
            var result2 = await cartegieAPi.GetInfosByCriteria("123", "");

            //Assert
            Assert.Null(result1);
            Assert.Null(result2);
        }

        [Fact]
        public async Task GetInfosByCriteria_GivenMultipleParamsWithNullOrEmptySocialReason_ShouldReturnSingleCustomer()
        {
            //Arrange
            HttpClientConfig("Multiple");
            // object with mocked params
            var cartegieAPi = new CartegieApi(mockConfig.Object, mockFactory.Object);

            //Act
            var result1 = await cartegieAPi.GetInfosByCriteria(null, "123");
            var result2 = await cartegieAPi.GetInfosByCriteria("", "123");

            //Assert
            Assert.Null(result1);
            Assert.Null(result2);
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
                return new StringContent("[{'adresse1': 'UBER PARTNER SUPPORT FRANCE SAS','siret':'81999478100022','apen700':'81999478100022'," +
                    "'adresse4':'81999478100022'}]");
            if (type.Equals("Multiple"))
                return new StringContent("[{'adresse1': 'UBER PARTNER SUPPORT FRANCE SAS','siret':'81999478100022','apen700':'81999478100022'," +
                    "'adresse4':'81999478100022'}, {'adresse1': 'UBER PARTNER SUPPORT FRANCE SAS','siret':'81999478100022','apen700':'81999478100022'," +
                    "'adresse4':'81999478100022'}]");

            return new StringContent("[{}]");
        }

        
    }
}

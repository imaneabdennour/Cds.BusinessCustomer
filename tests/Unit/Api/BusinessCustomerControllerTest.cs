using Cds.BusinessCustomer.Api.CustomerFeature;
using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Cds.BusinessCustomer.Api.Tests.Unit
{
    public class BusinessCustomerControllerTest
    {
        readonly Mock<ICartegieApi> mockService;
        readonly Mock<ILogger<BusinessCustomerController>> mockLogger;
        readonly Mock<IParametersHandler> mockHandler;

        public BusinessCustomerControllerTest()
        {
            mockService = new Mock<ICartegieApi>();
            mockLogger = new Mock<ILogger<BusinessCustomerController>>();
            mockHandler = new Mock<IParametersHandler>();
        }

        [Fact]
        public async Task SearchById_GivenValidId_ReturnsSingleCustomerViewModel()
        {
            // Arrange            
            var controller = new BusinessCustomerController(mockService.Object, mockLogger.Object, mockHandler.Object);
            // mock expected behavior when calling GetInfosById
            mockService.Setup(x => x.GetInfosById(It.IsAny<string>())).Returns(SingleTask());
            
            // Act
            var resById = await controller.SearchById("45");

            // Assert
            resById.Should().NotBeNull();
            resById.Result.Should().NotBeNull();
            (resById.Result as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task SearchByMultipleCriteria_GivenValidSiret_ReturnsSingleCustomerViewModel()
        {
            // Arrange            
            var controller = new BusinessCustomerController(mockService.Object, mockLogger.Object, mockHandler.Object);
            // mock expected behavior
            mockHandler.Setup(x => x.Validate(It.IsAny<string>())).Returns(true);
            mockService.Setup(x => x.GetInfosBySiret(It.IsAny<string>())).Returns(SingleTask());

            // Act
            var resBySiret = await controller.SearchByMultipleCriteria(null, null, "12345678978456");

            // Assert
            resBySiret.Should().NotBeNull();
            resBySiret.Result.Should().NotBeNull();
            (resBySiret.Result as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task SearchByMultipleCriteria_GivenSocialreasonAndZipcode_ReturnsListMultipleCustomerViewModel()
        {
            // Arrange            
            var controller = new BusinessCustomerController(mockService.Object, mockLogger.Object, mockHandler.Object);
            // mock expected behavior
            mockHandler.Setup(x => x.Validate(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            mockService.Setup(x => x.GetInfosByCriteria(It.IsAny<string>(), It.IsAny<string>())).Returns(MultipleTask());

            // Act
            var res =  await controller.SearchByMultipleCriteria("12", "34", null);

            // Assert
            res.Should().NotBeNull();
            res.Result.Should().NotBeNull();
            (res.Result as ObjectResult).StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

       
        private Task<CustomerSingleSearchDto> SingleTask()
        {
            return Task.FromResult(new CustomerSingleSearchDto()
            {
                Name = "Imane",
                Adress = "Maarif",
                City = "Casablanca",
                Civility = "Marocaine",
                NafCode = "35678899",
                Phone = "+21268085321",
                Siret = "78945612378456",
                SocialReason = "rs456",
                ZipCode = "20100"
            });
        }
        private Task<List<CustomerMultipleSearchDto>> MultipleTask()
        {
            return Task.FromResult(new List<CustomerMultipleSearchDto>()
            {
                new CustomerMultipleSearchDto {
                    Name = "Imane",
                    Adress = "Maarif",
                    Id = "1254",
                    SocialReason = "rs154"
                },
                new CustomerMultipleSearchDto {
                    Name = "Assia",
                    Adress = "Maarif",
                    Id = "1546",
                    SocialReason = "rs184"
                }
            });
        }

        private Task<CustomerSingleSearchDto> EmptyTask()
        {
            return Task.FromResult<CustomerSingleSearchDto>(null);
        }

    }
}

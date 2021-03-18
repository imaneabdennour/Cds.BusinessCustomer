using Cds.BusinessCustomer.Api.CustomerFeature;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Cds.BusinessCustomer.Api.Tests.Unit
{
    public class CustomerExtensionTest
    {
        CustomerSingleSearchDTO singleInput;
        List<CustomerMultipleSearchDTO> multipleInput;

        public CustomerExtensionTest()
        {
            singleInput = new CustomerSingleSearchDTO
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
            };

            multipleInput = new List<CustomerMultipleSearchDTO>()
            {
                new CustomerMultipleSearchDTO {
                    Name = "Imane",
                    Adress = "Maarif",
                    Id = "1254",
                    SocialReason = "rs154"
                },
                new CustomerMultipleSearchDTO {
                    Name = "Assia",
                    Adress = "Maarif",
                    Id = "1546",
                    SocialReason = "rs184"
                }
            };
        }

        [Fact]
        public void ToViewModel_GivenCustomerSingleSearchDTO_ReturnsSingleCustomerViewModel()
        {
            // Arrange

            // Act
            var actual = CustomerExtension.ToViewModel(singleInput);

            // Assert
            actual.Should().NotBeNull();
            actual.ZipCode.Should().Be("20100");
        }

        [Fact]
        public void ToViewModel_GivenListCustomerMultipleSearchDTO_ReturnsListMultipleCustomersViewModel()
        {
            // Arrange

            // Act
            var actual = CustomerExtension.ToViewModel(multipleInput);

            // Assert
            actual.Should().NotBeNull();
            actual.Should().NotBeEmpty();
        }
    }
}

using Cds.BusinessCustomer.Api.CustomerFeature.Validation;
using Cds.BusinessCustomer.Api.CustomerFeature.ViewModels;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Abstractions;
using Cds.BusinessCustomer.Infrastructure.CustomerRepository.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cds.BusinessCustomer.Api.CustomerFeature.Errors;
using Cds.BusinessCustomer.Api.CustomerFeature.Exceptions;
using System.Net;

namespace Cds.BusinessCustomer.Api.CustomerFeature
{
    /// <summary>
    /// Business Customer Controller
    /// </summary>
    [Route("business-customer-information/")]
    public class BusinessCustomerController : Controller
    {
        private readonly ICartegieApi _service;
        private readonly ILogger<BusinessCustomerController> _logger;
        private readonly IParametersHandler _handler;

        /// <summary>
        /// Constructor for BusinessCustomerController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        /// <param name="handler"></param>
        public BusinessCustomerController(ICartegieApi service, ILogger<BusinessCustomerController> logger, IParametersHandler handler)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _handler = handler ?? throw new ArgumentNullException(nameof(handler)); 
        }

        /// <summary>
        ///  Research by Social Reason and Zip Code OR Siret - of the information about the business customer
        /// </summary>
        /// <param name="socialReason"></param>
        /// <param name="zipCode"></param>
        /// <param name="siret"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleCustomerViewModel))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MultipleCustomersViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> SearchByMultipleCriteria([FromQuery] string socialReason, [FromQuery] string zipCode, [FromQuery] string siret)
        {
            try
            {
                if (string.IsNullOrEmpty(socialReason) && string.IsNullOrEmpty(zipCode) && string.IsNullOrEmpty(siret))
                    throw new ArgumentNullException(null, "You should enter non null Siret OR SocialReason and ZipCode");

                if (!string.IsNullOrEmpty(siret))
                {
                    var isValid = _handler.Validate(siret);
                    if (!isValid)
                        throw new BadRequestException("Invalid Siret - should be of length 14");
                    
                    CustomerSingleSearchDto response = await _service.GetInfosBySiret(siret);

                    if (response == null)
                        throw new NotFoundException("There is no business customer with such siret");

                    return Ok(response.ToViewModel());    
                }

                else if(!string.IsNullOrEmpty(zipCode) || !string.IsNullOrEmpty(socialReason))
                {
                    var isValid = _handler.Validate(socialReason, zipCode);
                    if (!isValid)
                        throw new BadRequestException("You should enter both SocialReason and ZipCode");

                    List<CustomerMultipleSearchDto> response = await _service.GetInfosByCriteria(socialReason, zipCode);

                    if (response == null)
                        throw new NotFoundException("There is no business customer with such social reason and zipcode");           


                    return Ok(response.ToViewModel());    
                }

                else
                {
                    throw new BadRequestException("You should enter valid Siret OR SocialReason and ZipCode");
                }
            }
            catch (ArgumentNullException e)
            {
                _logger.LogError($"ArgumentNullException : {e.Message}");
                return new BadRequestError(e.Message).Result;

            }
            catch (BadRequestException e)
            {
                _logger.LogError($"BadRequetException : {e.Message}");
                return new BadRequestError(e.Message).Result;
            }
            catch(NotFoundException e)
            {
                _logger.LogError($"NotFoundException :  {e.Message}");
                return new NotFoundError(e.Message).Result;           
            }
            catch (Exception)
            {
                _logger.LogError("Failed to retreive customers - Internal Server Error");
                return StatusCode(500);    
            }
        }

        /// <summary>
        /// Research by Id - of the information about the business customer
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleCustomerViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SingleCustomerViewModel>> SearchById([FromRoute] string Id)
        {
            try
            {
                CustomerSingleSearchDto response = await _service.GetInfosById(Id);
                if (response == null)
                {
                    throw new NotFoundException("There is no such business customer with such id");           
                }
                return Ok(response.ToViewModel());
            }
            catch(NotFoundException e)
            {
                _logger.LogError($"NotFoundException : {e.Message}");
                return new NotFoundError(e.Message).Result;
            }
            catch (Exception)
            {
                _logger.LogError("Failed to retreive customer - Internal Server Error");
                return StatusCode(500);     
            }
        }
       
    }
}

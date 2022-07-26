using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService) => _addressService = addressService;

        [HttpPost]
        public IActionResult Add(AddressDto address)
        {
            AddressValidator rules = new AddressValidator();
            ValidationResult result = rules.Validate(address);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _addressService.Add(address);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(AddressDto address)
        {
            AddressValidator rules = new AddressValidator();
            ValidationResult result = rules.Validate(address);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _addressService.Update(address);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _addressService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _addressService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

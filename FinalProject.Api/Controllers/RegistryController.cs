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
    [Authorize(Roles = "Reception")]
    public class RegistryController : ControllerBase
    {
        private readonly IRegistryService _registryService;
        public RegistryController(IRegistryService registryService) => _registryService = registryService;

        [HttpPost]
        public IActionResult Add(RegistryDto address)
        {
            RegistryValidator rules = new RegistryValidator();
            ValidationResult result = rules.Validate(address);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _registryService.Add(address);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(RegistryDto address)
        {
            RegistryValidator rules = new RegistryValidator();
            ValidationResult result = rules.Validate(address);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _registryService.Update(address);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _registryService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _registryService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

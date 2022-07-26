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
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinicService;
        public ClinicController(IClinicService clinicService) => _clinicService = clinicService;


        [HttpPost]
        public IActionResult Add(ClinicDto clinic)
        {
            ClinicValidator rules = new ClinicValidator();
            ValidationResult result = rules.Validate(clinic);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _clinicService.Add(clinic);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(ClinicDto clinic)
        {
            ClinicValidator rules = new ClinicValidator();
            ValidationResult result = rules.Validate(clinic);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _clinicService.Update(clinic);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _clinicService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _clinicService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

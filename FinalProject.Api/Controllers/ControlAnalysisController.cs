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
    [Authorize(Roles = "Doctor")]
    public class ControlAnalysisController : ControllerBase
    {
        private readonly IControlAnalysisService _controlAnalysisService;
        public ControlAnalysisController(IControlAnalysisService controlAnalysisService) =>_controlAnalysisService = controlAnalysisService;

        [HttpPost]
        public IActionResult Add(ControlAnalysisDto controlAnalysis)
        {
            ControlAnalysisValidator rules = new ControlAnalysisValidator();
            ValidationResult result = rules.Validate(controlAnalysis);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _controlAnalysisService.Add(controlAnalysis);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(ControlAnalysisDto controlAnalysis)
        {
            ControlAnalysisValidator rules = new ControlAnalysisValidator();
            ValidationResult result = rules.Validate(controlAnalysis);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _controlAnalysisService.Update(controlAnalysis);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _controlAnalysisService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _controlAnalysisService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

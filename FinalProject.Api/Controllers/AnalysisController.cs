
using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;
        private readonly IJwtService _jwtService;

        public AnalysisController(IAnalysisService analysisService, IJwtService jwtService)
        {
            _analysisService = analysisService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(AnalysisDto analysis)
        {
            AnalysisValidator rules = new AnalysisValidator();
            ValidationResult result = rules.Validate(analysis);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Doctor") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _analysisService.Add(analysis);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(AnalysisDto analysis)
        {
            AnalysisValidator rules = new AnalysisValidator();
            ValidationResult result = rules.Validate(analysis);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Doctor") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _analysisService.Update(analysis);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Doctor") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _analysisService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Doctor") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _analysisService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

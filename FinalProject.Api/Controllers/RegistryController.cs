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
    public class RegistryController : ControllerBase
    {
        private readonly IRegistryService _registryService;
        private readonly IJwtService _jwtService;

        public RegistryController(IRegistryService registryService, IJwtService jwtService)
        {
            _registryService = registryService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(RegistryDto address)
        {
            RegistryValidator rules = new RegistryValidator();
            ValidationResult result = rules.Validate(address);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Reception") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
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
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Reception") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _registryService.Update(address);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Reception") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _registryService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var role = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || role != "Reception") return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _registryService.GetAllData();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _registryService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

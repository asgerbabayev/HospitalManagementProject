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
    public class ControlController : ControllerBase
    {
        private readonly IControlService _controlService;
        private readonly IJwtService _jwtService;

        public ControlController(IControlService controlService, IJwtService jwtService)
        {
            _controlService = controlService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(ControlDto control)
        {
            ControlValidator rules = new ControlValidator();
            ValidationResult result = rules.Validate(control);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _controlService.Add(control);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(ControlDto control)
        {
            ControlValidator rules = new ControlValidator();
            ValidationResult result = rules.Validate(control);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _controlService.Update(control);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _controlService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _controlService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _controlService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

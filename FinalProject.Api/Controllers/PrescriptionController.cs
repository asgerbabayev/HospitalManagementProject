using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IJwtService _jwtService;

        public PrescriptionController(IJwtService jwtService, IPrescriptionService prescriptionService)
        {
            _jwtService = jwtService;
            _prescriptionService = prescriptionService;
        }

        [HttpPost]
        public IActionResult Add(PrescriptionDto prescription)
        {
            PrescriptionValidator rules = new PrescriptionValidator();
            ValidationResult result = rules.Validate(prescription);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            var a = verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value;
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _prescriptionService.Add(prescription);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(PrescriptionDto prescription)
        {
            PrescriptionValidator rules = new PrescriptionValidator();
            ValidationResult result = rules.Validate(prescription);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _prescriptionService.Update(prescription);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _prescriptionService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _prescriptionService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                           verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Doctor")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _prescriptionService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

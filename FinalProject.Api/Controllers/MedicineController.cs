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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IJwtService _jwtService;

        public MedicineController(IMedicineService medicineService, IJwtService jwtService)
        {
            _medicineService = medicineService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(MedicineDto medicine)
        {
            MedicineValidator rules = new MedicineValidator();
            ValidationResult result = rules.Validate(medicine);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _medicineService.Add(medicine);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(MedicineDto medicine)
        {
            MedicineValidator rules = new MedicineValidator();
            ValidationResult result = rules.Validate(medicine);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _medicineService.Update(medicine);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _medicineService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success)
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _medicineService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _medicineService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IJwtService _jwtService;

        public EmployeeController(IEmployeeService employeeService, IJwtService jwtService)
        {
            _employeeService = employeeService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(EmployeeDto employee)
        {
            EmployeeValidator rules = new EmployeeValidator();
            ValidationResult result = rules.Validate(employee);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var doctorToAdd = _employeeService.Add(employee);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpPut]
        public IActionResult Update(EmployeeDto employee)
        {
            EmployeeValidator rules = new EmployeeValidator();
            ValidationResult result = rules.Validate(employee);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var doctorToAdd = _employeeService.Update(employee);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _employeeService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                      verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _employeeService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }


        [HttpGet("doctors")]
        public IActionResult GetAllDoctor()
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                      verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _employeeService.GetAllDoctor();
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
            var result = _employeeService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("confirmation/{email}")]
        public ContentResult Confirmation(string email)
        {
            var result = _employeeService.CheckIsConfirmedAccount(email);
            if (!result.Success) return Content("<h1 style='font-size: 55px; margin-top:250px; text-align: center; color:rgb(15, 166, 226)'>Hesabınız daha əvvəl təsdiqlənib</h1>", "text/html");
            return Content(_employeeService.ConfirmationMessage(), "text/html");
        }
    }
}

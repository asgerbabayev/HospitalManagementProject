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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;

        [HttpPost]
        public IActionResult Add(EmployeeDto employee)
        {
            DoctorValidator rules = new DoctorValidator();
            ValidationResult result = rules.Validate(employee);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var doctorToAdd = _employeeService.Add(employee);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpPut]
        public IActionResult Update(EmployeeDto employee)
        {
            DoctorValidator rules = new DoctorValidator();
            ValidationResult result = rules.Validate(employee);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var doctorToAdd = _employeeService.Update(employee);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("confirmation/{email}")]
        public ContentResult Confirmation(string email)
        {
            var result = _employeeService.CheckIsConfirmedAccount(email);
            if (!result.Success) return Content("<h1 style='font-size: 55px; margin-top:250px; text-align: center; color:rgb(15, 166, 226)'>Your Account Already Verified.</h1>", "text/html");
            return Content(_employeeService.ConfirmationMessage(), "text/html");
        }
    }
}

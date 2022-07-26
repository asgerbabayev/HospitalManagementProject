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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService) => _doctorService = doctorService;

        [HttpPost]
        public IActionResult Add(DoctorDto doctor)
        {
            DoctorValidator rules = new DoctorValidator();
            ValidationResult result = rules.Validate(doctor);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var doctorToAdd = _doctorService.Add(doctor);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpPut]
        public IActionResult Update(DoctorDto doctor)
        {
            DoctorValidator rules = new DoctorValidator();
            ValidationResult result = rules.Validate(doctor);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var doctorToAdd = _doctorService.Update(doctor);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _doctorService.Delete(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _doctorService.GetAll();
            if (!result.Success) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("confirmation/{email}")]
        [AllowAnonymous]
        public ContentResult Confirmation(string email)
        {
            var result = _doctorService.CheckIsConfirmedAccount(email);
            if (!result.Success) return Content("<h1 style='font-size: 75px; margin-top:250px; text-align: center; color:rgb(15, 166, 226)'>Your Account Already Verified.</h1>", "text/html");
            return Content(_doctorService.ConfirmationMessage(), "text/html");
        }

    }
}

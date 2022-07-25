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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("AddDoctor"), Authorize(Roles = "Admin")]
        public IActionResult Add(DoctorAddDto doctorAdd)
        {
            DoctorValidator rules = new DoctorValidator();
            ValidationResult result = rules.Validate(doctorAdd);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var doctorToAdd = _doctorService.Add(doctorAdd);
            if (!doctorToAdd.Success) return StatusCode(StatusCodes.Status400BadRequest, doctorToAdd.Message);
            return Ok(doctorToAdd);
        }

        [HttpPost("confirmation/{email}")]
        public ContentResult Confirmation(string email)
        {
            var result = _doctorService.CheckIsConfirmedAccount(email);
            if (!result.Success) return Content("<h1 style='font-size: 75px; margin-top:250px; text-align: center; color:rgb(15, 166, 226)'>Your Account Already Verified.</h1>", "text/html");
            return Content(_doctorService.ConfirmationMessage(), "text/html");
        }
    }
}

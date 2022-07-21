using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Extensions;
using FinalProject.Core.Utilities.IoC;
using FinalProject.Entities.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Authorize]
        public IActionResult GetUsers()
        {
            var c = User.Claims(ClaimTypes.Email);
            return Ok(c);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            LoginValidator loginValidation = new LoginValidator();
            ValidationResult results = loginValidation.Validate(loginDto);
            if (!results.IsValid)
            {
                foreach (var e in results.Errors)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
                }
            }
            var userToLogin = _userService.Login(loginDto);
            if (!userToLogin.Success) return StatusCode(StatusCodes.Status400BadRequest, userToLogin);

            var result = _userService.CreateAccessToken(userToLogin.Data);
            if (result.Success) return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, result);
        }
    }
}

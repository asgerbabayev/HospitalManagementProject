using FinalProject.Business.Abstract;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web.Http.Controllers;

namespace FinalProject.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IJwtService _jwtService;

        public AuthController(IEmployeeService employeeService, IJwtService jwtService)
        {
            _employeeService = employeeService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            LoginValidator loginValidation = new LoginValidator();
            ValidationResult results = loginValidation.Validate(loginDto);
            if (!results.IsValid)
                foreach (var e in results.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var resultService = _employeeService.Login(loginDto);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService);
            var result = _employeeService.CreateAccessToken(resultService.Data);
            Response.Cookies.Append("token", result.Data.Token, new CookieOptions { HttpOnly = true, Path = "/", Expires = result.Data.Expiration, SameSite = SameSiteMode.None, Secure = true });
            if (result.Success) return Ok(new {result, resultService, message = "Giriş etdiniz" });
            return StatusCode(StatusCodes.Status400BadRequest, result);
        }

        [HttpPost("resetpasswordmail")]
        public IActionResult ResetPasswordMail(string email)
        {
            var isExist = _employeeService.GetByEmail(email);
            if (!isExist.Success) return StatusCode(StatusCodes.Status400BadRequest, isExist);
            var result = _employeeService.SendResetPasswordMail(email);
            if (!result.Success) return StatusCode(StatusCodes.Status400BadRequest, result);
            var jwt = _employeeService.CreateAccessToken(isExist.Data);
            jwt.Data.Expiration = DateTime.Now.AddMinutes(1);
            Response.Cookies.Append("emailtoken", jwt.Data.Token, new CookieOptions { HttpOnly = true, Path = "/", Expires = jwt.Data.Expiration, SameSite = SameSiteMode.None, Secure = true });
            return Ok(new { message = "Şifrə sıfırlama maili göndərildi" });
        }

        [HttpPost("resetpassword")]
        public IActionResult ResetPassword(string email, string password)
        {
            var token = Request.Cookies["emailtoken"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (token != "") Response.Cookies.Append("emailtoken", "", new CookieOptions { HttpOnly = true, Path = "/", SameSite = SameSiteMode.None, Secure = true });
            if (!verifyToken.Success) return BadRequest(new { message = "Bu əməliyyatın istifadə müddəti bitmişdir." });
            var resultService = _employeeService.ResetPassword(email, password);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService);
            return Ok(resultService);
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            Response.Cookies.Append("emailtoken", "", new CookieOptions { HttpOnly = true, Path = "/", SameSite = SameSiteMode.None, Secure = true });
            return Ok();
        }
    }
}

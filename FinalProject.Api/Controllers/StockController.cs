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
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService; 
        private readonly IJwtService _jwtService;

        public StockController(IStockService stockService, IJwtService jwtService)
        {
            _stockService = stockService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Add(StockDto stock)
        {
            StockValidator rules = new StockValidator();
            ValidationResult result = rules.Validate(stock);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _stockService.Add(stock);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpPut]
        public IActionResult Update(StockDto stock)
        {
            StockValidator rules = new StockValidator();
            ValidationResult result = rules.Validate(stock);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return StatusCode(StatusCodes.Status400BadRequest, e.ErrorMessage);
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var resultService = _stockService.Update(stock);
            if (!resultService.Success) return StatusCode(StatusCodes.Status400BadRequest, resultService.Message);
            return Ok(resultService);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _stockService.Delete(id);
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
            var result = _stockService.GetAll();
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var token = Request.Cookies["token"];
            var verifyToken = _jwtService.VerifyToken(token);
            if (!verifyToken.Success || verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Admin" &&
                            verifyToken.Data.Claims.FirstOrDefault(x => x.Type == RoleType.Type).Value != "Reception")
                return Unauthorized(new { message = "Bu əməliyyat üçün icazəniz yoxdur" });
            var result = _stockService.GetById(id);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}

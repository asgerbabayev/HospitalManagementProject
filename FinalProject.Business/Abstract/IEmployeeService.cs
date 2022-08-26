using FinalProject.Core.Utilities.Results;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(EmployeeDto employeeDto);
        IResult Update(EmployeeDto employeeDto);
        IResult Delete(int Id);
        IDataResult<Employee> GetById(int id);
        IDataResult<Employee> GetByEmail(string email);
        IDataResult<List<Employee>> GetAll();
        IDataResult<List<Employee>> GetAllDoctor();
        IDataResult<Employee> Login(LoginDto loginDto);
        IDataResult<AccessToken> CreateAccessToken(Employee employee);
        IResult CheckIsConfirmedAccount(string email);
        IResult SendResetPasswordMail(string email);
        IDataResult<Employee> ResetPassword(string email, string password);
        string ConfirmationMessage();
    }
}

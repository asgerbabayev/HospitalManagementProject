using AutoMapper;
using FinalProject.Core.Utilities.Security.Mail;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Core.Utilities.Business;
using FinalProject.Core.Utilities.Results;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Core.Utilities.Security.Hashing;
using System.IdentityModel.Tokens.Jwt;

namespace FinalProject.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly MailHelper _mailHelper;
        public EmployeeManager(IEmployeeDal employeeDal, IMapper mapper, MailHelper mailHelper, ITokenHelper tokenHelper)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
            _mailHelper = mailHelper;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Employee> Login(LoginDto loginDto)
        {
            var doctorExist = _employeeDal.Get(e => e.Email == loginDto.Email);
            if (doctorExist == null) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            //loginDto.Password = BCrypt.Net.BCrypt.HashPassword(loginDto.Password);
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, doctorExist.Password)) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            if (doctorExist.EmailConfirmation == false) return new ErrorDataResult<Employee>(Messages.EmailIsNotConfirmed);
            return new SuccessDataResult<Employee>(doctorExist, Messages.LoggedIn);
        }

        public IResult Add(EmployeeDto employeeAddDto)
        {
            employeeAddDto.Password = BCrypt.Net.BCrypt.HashPassword(employeeAddDto.Password);
            employeeAddDto.RoleId = 2;
            var result = BusinessRules.Run(CheckEmail(employeeAddDto.Email),
                CheckIdentificationNumber(employeeAddDto.IdentificationNumber),
                CheckPhoneNumber(employeeAddDto.PhoneNumber), SendConfirmationMail(employeeAddDto.Email));
            if (!result.Success) return new ErrorResult(result.Message);
            _employeeDal.Add(_mapper.Map<Employee>(employeeAddDto));
            return new Result(true, Messages.EmployeeAdded);
        }

        public IDataResult<Employee> GetById(int id)
        {
            var result = _employeeDal.Get(x => x.Id == id);
            if (result == null) return new ErrorDataResult<Employee>(Messages.InvalidEmail);
            return new SuccessDataResult<Employee>(result);
        }

        public IDataResult<Employee> GetByEmail(string email)
        {
            var result = _employeeDal.Get(x => x.Email == email);
            if (result == null) return new ErrorDataResult<Employee>(Messages.InvalidEmail);
            return new SuccessDataResult<Employee>(result);
        }


        public IResult Update(EmployeeDto employeeUpdateDto)
        {
            var result = _employeeDal.Get(x => x.Email == employeeUpdateDto.Email);
            if (result.EmailConfirmation == true)
                employeeUpdateDto.EmailConfirmation = true;
            _employeeDal.Update(_mapper.Map<Employee>(employeeUpdateDto));
            return new Result(true, Messages.EmployeeUpdated);
        }
        public IResult Delete(int id)
        {
            var employee = _employeeDal.Get(d => d.Id == id);
            _employeeDal.Delete(employee);
            return new Result(true, Messages.EmployeeDeleted);
        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetEmployeesWithRole(), Messages.EmployeesListed);
        }
        public IDataResult<List<Employee>> GetAllDoctor()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAllDoctor(), Messages.EmployeesListed);
        }

        public IResult SendResetPasswordMail(string email)
        {
            var message = new MailRequest()
            {
                To = email,
                Subject = "Şifrə Sıfırlama",
                Content = _mailHelper.ResetPasswordMailContent(email)
            };
            try
            {
                _mailHelper.SendMail(message);
                return new SuccessResult(Messages.PasswordResetEmailSended);
            }
            catch (Exception)
            {
                return new ErrorResult("Xəta baş verdi təkrar yoxlayın");
            }
        }
        public IDataResult<Employee> ResetPassword(string email, string password)
        {
            if(email == null) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            email = HashString.Decode(email);
            var employeeExist = _employeeDal.Get(e => e.Email == email);
            if (employeeExist == null) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            password = BCrypt.Net.BCrypt.HashPassword(password);
            _employeeDal.Update(employeeExist);
            return new SuccessDataResult<Employee>(employeeExist, Messages.PasswordChangedSuccessfully);
        }

        public IDataResult<Employee> ChangePassword(string email, string oldPassword, string newPassword)
        {
            var employeeExist = _employeeDal.Get(e => e.Email == email);
            if (employeeExist == null) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, employeeExist.Password)) return new ErrorDataResult<Employee>(Messages.InvalidCredentials);
            employeeExist.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            return new SuccessDataResult<Employee>(employeeExist, Messages.PasswordChangedSuccessfully);
        }
        public IDataResult<List<Role>> GetClaims(Employee doctor)
        {
            return new SuccessDataResult<List<Role>>(_employeeDal.GetClaims(doctor));
        }
        public IDataResult<AccessToken> CreateAccessToken(Employee doctor)
        {
            var claims = GetClaims(doctor).Data;
            var accessToken = _tokenHelper.CreateToken(doctor, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }
        public IResult SendConfirmationMail(string email)
        {
            var message = new MailRequest()
            {
                To = email,
                Subject = "Təsdiqləmə Maili",
                Content = _mailHelper.ConfirmationMailContent(email)
            };
            try
            {
                _mailHelper.SendMail(message);
                return new SuccessResult();
            }
            catch (Exception)
            {
                return new ErrorResult("Xəta baş verdi təkrar yoxlayın");
            }
        }

        public IResult CheckIsConfirmedAccount(string email)
        {
            email = HashString.Decode(email);
            var result = _employeeDal.Get(e => e.Email == email);
            if (result.EmailConfirmation == false)
            {
                result.EmailConfirmation = true;
                _employeeDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public string ConfirmationMessage()
        {
            return _mailHelper.SuccessConfirmation();
        }

        private IResult CheckIdentificationNumber(string idnNumber)
        {
            var result = _employeeDal.GetAll(idn => idn.IdentificationNumber == idnNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.IdentificationNumberAlreadyHave);
        }

        private IResult CheckPhoneNumber(string phoneNumber)
        {
            var result = _employeeDal.GetAll(i => i.PhoneNumber == phoneNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.PhoneNumberAlreadyHave);
        }
        private IResult CheckEmail(string email)
        {
            var result = _employeeDal.GetAll(a => a.Email == email).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.EmailAlreadyHave);
        }

    }
}

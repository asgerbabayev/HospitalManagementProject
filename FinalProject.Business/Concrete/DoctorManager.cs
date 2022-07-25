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
using System.Text;
using FinalProject.Core.Utilities.Security.JWT;

namespace FinalProject.Business.Concrete
{
    public class DoctorManager : IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly MailHelper _mailHelper;
        public DoctorManager(IDoctorDal doctorDal, IMapper mapper, MailHelper mailHelper, ITokenHelper tokenHelper)
        {
            _doctorDal = doctorDal;
            _mapper = mapper;
            _mailHelper = mailHelper;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Doctor> Login(LoginDto loginDto)
        {
            var doctorExist = _doctorDal.Get(e => e.Email == loginDto.Email);
            if (doctorExist == null) return new ErrorDataResult<Doctor>(Messages.InvalidCredentials);
            doctorExist.Password = BCrypt.Net.BCrypt.HashPassword(loginDto.Password);
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, doctorExist.Password)) return new ErrorDataResult<Doctor>(Messages.InvalidCredentials);
            if (doctorExist.EmailConfirmation == false) return new ErrorDataResult<Doctor>(Messages.EmailIsNotConfirmed);
            return new SuccessDataResult<Doctor>(doctorExist, Messages.LoggedIn);
        }

        public IDataResult<Doctor> ChangePassword(string email, string oldPassword, string newPassword)
        {
            var doctorExist = _doctorDal.Get(e => e.Email == email);
            if (doctorExist == null) return new ErrorDataResult<Doctor>(Messages.InvalidCredentials);
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, doctorExist.Password)) return new ErrorDataResult<Doctor>(Messages.InvalidCredentials);
            doctorExist.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            return new SuccessDataResult<Doctor>(doctorExist, Messages.PasswordChangedSuccessfully);
        }
        public IDataResult<List<Role>> GetClaims(Doctor doctor)
        {
            return new SuccessDataResult<List<Role>>(_doctorDal.GetClaims(doctor));
        }
        public IDataResult<AccessToken> CreateAccessToken(Doctor doctor)
        {
            var claims = GetClaims(doctor).Data;
            var accessToken = _tokenHelper.CreateToken(doctor, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public IResult Add(DoctorAddDto doctorAddDto)
        {
            doctorAddDto.Password = BCrypt.Net.BCrypt.HashPassword(doctorAddDto.Password);
            doctorAddDto.RoleId = 2;
            doctorAddDto.Status = false;
            var result = BusinessRules.Run(CheckEmail(doctorAddDto.Email),
                CheckIdentificationNumber(doctorAddDto.IdentificationNumber),
                CheckPhoneNumber(doctorAddDto.PhoneNumber), SendConfirmationMail(doctorAddDto.Email));
            if (!result.Success) return new ErrorResult(result.Message);
            _doctorDal.Add(_mapper.Map<Doctor>(doctorAddDto));

            return new Result(true, result.Message);
        }

        public IResult Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(DoctorAddDto doctorAddDto)
        {
            throw new NotImplementedException();
        }

        public IResult SendConfirmationMail(string email)
        {
            var message = new MailRequest()
            {
                To = email,
                Subject = "Mail Confirmation",
                Content = _mailHelper.MailContent(email)
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
            var result = _doctorDal.Get(e => e.Email == email);
            if (result.EmailConfirmation == false)
            {
                result.EmailConfirmation = true;
                _doctorDal.Update(result);
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
            var result = _doctorDal.GetAll(idn => idn.IdentificationNumber == idnNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.IdentificationNumberAlreadyHave);
        }

        private IResult CheckPhoneNumber(string phoneNumber)
        {
            var result = _doctorDal.GetAll(i => i.PhoneNumber == phoneNumber).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.PhoneNumberAlreadyHave);
        }
        private IResult CheckEmail(string email)
        {
            var result = _doctorDal.GetAll(a => a.Email == email).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult(Messages.EmailAlreadyHave);
        }
    }
}

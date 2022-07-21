using AutoMapper;
using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Business.ValidationRules.FluentValidation;
using FinalProject.Core.Utilities.Business;
using FinalProject.Core.Utilities.Results;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.DataAccess.Abstract;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        private ITokenHelper _tokenHelper;
        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IMapper mapper)
        {
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _userDal = userDal;
        }

        public IDataResult<User> Login(LoginDto loginDto)
        {
            var userExist = _userDal.Get(e => e.Email == loginDto.Email);
            if (userExist == null) return new ErrorDataResult<User>(Messages.InvalidCredentials);
            userExist.Password = BCrypt.Net.BCrypt.HashPassword(loginDto.Password);
            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, userExist.Password)) return new ErrorDataResult<User>(Messages.InvalidCredentials);
            return new SuccessDataResult<User>(userExist, Messages.LoggedIn);
        }

        public IDataResult<User> Password(string email,string oldPassword, string newPassword)
        {
            var userExist = _userDal.Get(e => e.Email == email);
            if (userExist == null) return new ErrorDataResult<User>(Messages.InvalidCredentials);
            if (!BCrypt.Net.BCrypt.Verify(oldPassword, userExist.Password)) return new ErrorDataResult<User>(Messages.InvalidCredentials);
            userExist.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            return new SuccessDataResult<User>(userExist, Messages.PasswordChangedSuccessfully);
        }
        public IDataResult<List<Role>> GetClaims(User user)
        {
            return new SuccessDataResult<List<Role>>(_userDal.GetClaims(user));
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        private IResult CheckEmail(string email)
        {
            var result = _userDal.GetAll(a => a.Email == email).Count();
            if (result == 0) return new SuccessResult();
            return new ErrorResult("This email already have");
        }

        public IDataResult<List<User>> GetUser()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }
    }
}

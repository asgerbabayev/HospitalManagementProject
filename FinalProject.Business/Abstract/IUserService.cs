using FinalProject.Core.Utilities.Results;
using FinalProject.Core.Utilities.Security.JWT;
using FinalProject.Entities.Concrete;
using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<User> Login(LoginDto loginDto);
        public IDataResult<AccessToken> CreateAccessToken(User user);
        public IDataResult<List<User>> GetUser();
    }
}

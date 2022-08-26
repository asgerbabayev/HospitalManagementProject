using FinalProject.Business.Abstract;
using FinalProject.Business.Constants;
using FinalProject.Core.Utilities.Results;
using FinalProject.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FinalProject.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        private readonly ITokenHelper _tokenHelper;

        public JwtManager(ITokenHelper tokenHelper) => _tokenHelper = tokenHelper;
        public IDataResult<JwtSecurityToken> VerifyToken(string token)
        {
            try
            {
                var result = _tokenHelper.Verify(token);
                return new SuccessDataResult<JwtSecurityToken>(result, Messages.TokenVerified);
            }
            catch (Exception)
            {
                return new ErrorDataResult<JwtSecurityToken>(Messages.InvalidCredentials);
            }
        }


    }
}

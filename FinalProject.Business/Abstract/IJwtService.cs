using FinalProject.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FinalProject.Business.Abstract
{
    public interface IJwtService
    {
        IDataResult<JwtSecurityToken> VerifyToken(string token);
    }
}

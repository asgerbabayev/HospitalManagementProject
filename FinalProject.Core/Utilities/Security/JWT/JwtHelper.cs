using FinalProject.Core.Extensions;
using FinalProject.Core.Utilities.Security.Encryption;
using FinalProject.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FinalProject.Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        public AccessToken CreateToken(Employee employee, List<Role> role)
        {
            _accessTokenExpiration = DateTime.Now.AddHours(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, employee, signingCredentials, role);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken Verify(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenOptions.SecurityKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            return (JwtSecurityToken)validatedToken;
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Employee employee,
            SigningCredentials signingCredentials, List<Role> role)
        {
            var jwt = new JwtSecurityToken(
                issuer: employee.Id.ToString(),
                audience: null,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(employee, role),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(Employee employee, List<Role> role)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(employee.Id.ToString());
            claims.AddEmail(employee.Email);
            claims.AddRoles(role.Select(u => u.Name).ToArray());

            return claims;
        }

    }
}

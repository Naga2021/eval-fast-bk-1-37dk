using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FortCode.Services
{
    public class TokenService : ITokenService
    {
        public TokenService(IConfiguration config)
        {

        }
        public string CreateToken(string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FortRobotics@SecurityKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("Issuer","FortRobotics"),
                new Claim(JwtRegisteredClaimNames.UniqueName,userName) };

            var token = new JwtSecurityToken(
                "FortRobotics",
                "FortRobotics",
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}

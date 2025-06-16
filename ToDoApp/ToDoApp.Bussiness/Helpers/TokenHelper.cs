using ToDoApp.Entities;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using ToDoApp.Entities.Configurations;
using System.IdentityModel.Tokens.Jwt;
namespace ToDoApp.Bussiness.Helpers
{
    public  class TokenHelper
    {
        private readonly JwtOptions _jwtOptions;

        public TokenHelper(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public  string CreateToken(ToDoUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name+" "+user.Surname)

            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key!));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtOptions.Issuer, _jwtOptions.Audience, claims, expires: DateTime.Now.AddHours(1), signingCredentials: creds);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
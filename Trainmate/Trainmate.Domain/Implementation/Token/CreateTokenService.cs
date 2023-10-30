
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Trainmate.Domain.Interfaces.Token;
using Trainmate.Repositories.Entities;
namespace Trainmate.Domain.Implementation.Token
{
    public class CreateTokenService : ICreateTokenService
    {
        private readonly IConfiguration _configuration;

        public CreateTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Execute(User user)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.PrimarySid, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Role, user.Role.Description),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration.GetSection("Jwt:ExpirationToken").Value)),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

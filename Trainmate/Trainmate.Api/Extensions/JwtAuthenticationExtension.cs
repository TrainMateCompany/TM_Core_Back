using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Trainmate.Api.Extensions
{
    public static class JwtAuthenticationExtension
    {
        public static IConfiguration _configuration { get; set; }
        public static void AddJwtAuthentication(this IServiceCollection services, WebApplicationBuilder builder)
        {
            _configuration = builder.Configuration;
            string jwtToken = builder.Configuration.GetSection("Jwt:Token").Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtToken)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}

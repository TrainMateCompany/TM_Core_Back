

using Bios_Back.Domain.Implementation.Login;
using FluentValidation;
using Trainmate.Common.Dto;
using Trainmate.Common.Validators;
using Trainmate.Domain.Implementation.Login;
using Trainmate.Domain.Implementation.Token;
using Trainmate.Domain.Interfaces.Login;
using Trainmate.Domain.Interfaces.Token;
using Trainmate.Repositories.Repositories.Implementation;
using Trainmate.Repositories.Repositories.Interfaces;

namespace Trainmate.Api.Extensions
{
    public static class DiExtensions
    {
        public static void RegisterServices(this IServiceCollection services, WebApplicationBuilder? builder)
        {

            // Fluent Validations
            services.AddSingleton<IValidator<LoginDto>, LoginValidator>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserRepository, UserRepository>();

            // Add AutoMapper


            services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddTransient<ICreateTokenService, CreateTokenService>();
            services.AddTransient<IActiveDirectoryService, ActiveDirectoryService>();
        }
    }
}

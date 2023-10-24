

namespace Trainmate.Api.Extensions
{
    public static class DiExtensions
    {
        public static void RegisterServices(this IServiceCollection services, WebApplicationBuilder? builder)
        {


            // Add AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

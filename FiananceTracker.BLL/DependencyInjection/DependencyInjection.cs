using FiananceTracker.BLL.Services.Implementations;
using FiananceTracker.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiananceTracker.BLL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
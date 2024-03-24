using FinanceTracker.Application.Repository;
using FinanceTracker.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
using FinanceTracker.Application.Commands.User;
using FinanceTracker.Application.Repository;
using FinanceTracker.DAL.Commands;
using FinanceTracker.DAL.Database;
using FinanceTracker.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceTracker.DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQLServer")));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddMediatR(x =>
                x.RegisterServicesFromAssemblies(typeof(CreateUserHandler).Assembly, typeof(CreateUserCommand).Assembly));

            return services;
        }
    }
}

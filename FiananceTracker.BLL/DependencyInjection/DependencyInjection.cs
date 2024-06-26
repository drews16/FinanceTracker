﻿using FiananceTracker.BLL.Helpers;
using FiananceTracker.BLL.Services.Implementations;
using FiananceTracker.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiananceTracker.BLL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<PasswordHasherHelper>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExcelService, ExcelService>();
            
            return services;
        }
    }
}
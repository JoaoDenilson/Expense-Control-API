using AutoMapper;
using Expense_Control.API.Data;
using Expense_Control.API.Domain.Repository.Classes;
using Expense_Control.API.Domain.Repository.Interfaces;
using Expense_Control.API.Domain.Services.Interfaces;
using Expense_Control.API.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Expense_Control.API.AutoMapper;

namespace Expense_Control.API.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            var config = new MapperConfiguration(o =>
            {
                o.AddProfile<UserProfile>();
            });

            IMapper mapper = config.CreateMapper();

            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<TokenService>()
                .AddSingleton(mapper);

            return services;
        }
    }
}

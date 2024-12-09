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
using Expense_Control.API.Contract.NatureLaunch;

namespace Expense_Control.API.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            var config = new MapperConfiguration(o =>
            {
                o.AddProfile<UserProfile>();
                o.AddProfile<NatureLaunchProfile>();
                o.AddProfile<TitleToPayProfile>();
                o.AddProfile<TitleToReceiveProfile>();
            });

            IMapper mapper = config.CreateMapper();

            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<INatureLaunchRepository, NatureLaunchRepository>()
                .AddScoped<ITitleToPayRepository, TitleToPayRepository>()
                .AddScoped<ITitleToReceiveRepository, TitleToReceiveRepository>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IService<NatureLaunchRequestDTO, NatureLaunchResponseDTO, long>, NatureLaunchService>()
                .AddScoped<IService<TitleToPayRequestDTO, TitleToPayResponseDTO, long>, TitleToPayService>()
                .AddScoped<IService<TitleToReceiveRequestDTO, TitleToReceiveResponseDTO, long>, TitleToReceiveService>()
                .AddScoped<TokenService>()
                .AddSingleton(mapper);

            return services;
        }
    }
}

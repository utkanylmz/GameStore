using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using GameStore.Application.Features.Users.Rules;
using GameStore.Application.Features.GameDevelopers.Rules;
using GameStore.Application.Features.GameTypes.Rules;
using GameStore.Application.Features.Games.Rules;
using GameStore.Application.Features.Auths.Rules;
using GameStore.Application.Services.AuthService;
using Core.Application.Pipelines.Authorization;

namespace GameStore.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<GameBusinessRules>();
            services.AddScoped<GameTypeBusinessRules>();
            services.AddScoped<GameDeveloperBusinessRules>();
            services.AddScoped<AuthBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>();
            return services;
        }
    }
}

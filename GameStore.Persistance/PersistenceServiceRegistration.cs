using GameStore.Application.Services.Repositories;
using GameStore.Persistance.Context;
using GameStore.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(
                                                    configuration.GetConnectionString("GameStoreProjectConnectionString")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameTypeRepository, GameTypeRepository>();
            services.AddScoped<IGameDeveloperRepository,GameDeveloperRepository>();

            return services;
        }
    }
}

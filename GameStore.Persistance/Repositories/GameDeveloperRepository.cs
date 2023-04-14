using Core.Persistence.Repositories;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using GameStore.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Persistance.Repositories
{
    public class GameDeveloperRepository:EfRepositoryBase<GameDeveloper,BaseDbContext>,IGameDeveloperRepository
    {
        public GameDeveloperRepository(BaseDbContext context):base(context)
        {
            
        }
    }
}

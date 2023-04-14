using Core.Persistence.Repositories;
using GameStore.Domain.Entities;

namespace GameStore.Application.Services.Repositories
{
    public interface IGameRepository:IAsyncRepository<Game>,IRepository<Game>
    {
    }
}

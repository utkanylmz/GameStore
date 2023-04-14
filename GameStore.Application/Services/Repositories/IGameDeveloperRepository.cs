using Core.Persistence.Repositories;
using GameStore.Domain.Entities;

namespace GameStore.Application.Services.Repositories
{
    public interface IGameDeveloperRepository: IAsyncRepository<GameDeveloper>, IRepository<GameDeveloper>
    {
    }
}

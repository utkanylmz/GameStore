using Core.Persistence.Repositories;
using GameStore.Domain.Entities;

namespace GameStore.Application.Services.Repositories
{
    public interface IGameTypeRepository: IAsyncRepository<GameType>, IRepository<GameType>
    {
    }
}

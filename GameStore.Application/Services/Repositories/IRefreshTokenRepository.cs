using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace GameStore.Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {
    }

}

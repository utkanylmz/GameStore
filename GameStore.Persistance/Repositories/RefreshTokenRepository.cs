using Core.Persistence.Repositories;
using Core.Security.Entities;
using GameStore.Application.Services.Repositories;
using GameStore.Persistance.Context;

namespace GameStore.Persistance.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {

        }
    }
}

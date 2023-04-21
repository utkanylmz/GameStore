using Core.Persistence.Repositories;
using Core.Security.Entities;
using GameStore.Application.Services.Repositories;
using GameStore.Persistance.Context;

namespace GameStore.Persistance.Repositories
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {

        }
    }
}

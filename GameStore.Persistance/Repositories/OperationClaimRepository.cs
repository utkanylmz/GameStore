using Core.Persistence.Repositories;
using Core.Security.Entities;
using GameStore.Application.Services.Repositories;
using GameStore.Persistance.Context;

namespace GameStore.Persistance.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {

        }
    }
}

using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.UserOperationClaims.Models
{
    public class GetListUserOperationClaimsModel:BasePageableModel
    {
        public IList<UserOperationClaim> Items { get; set; }
    }
}

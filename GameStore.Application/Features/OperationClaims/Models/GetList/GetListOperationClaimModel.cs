﻿using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.OperationClaims.Models.GetList
{
    public class GetListOperationClaimModel:BasePageableModel
    {
        public IList<OperationClaim> Items { get; set; }
    }
}

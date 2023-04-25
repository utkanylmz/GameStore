using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Core.Security.Entities;
using GameStore.Application.Features.UserOperationClaims.Models;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.UserOperationClaims.Queries.GetList
{
    public class GetListUserOperationClaimQuery:IRequest<GetListUserOperationClaimsModel>
    {
        public PageRequest PageRequest { get; set; }
    }

    public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, GetListUserOperationClaimsModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<GetListUserOperationClaimsModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
        {
          IPaginate<UserOperationClaim> userOpeationClaim=  await _userOperationClaimRepository.GetListAsync
                                                             (size: request.PageRequest.PageSize, index: request.PageRequest.Page);
            GetListUserOperationClaimsModel getListUserOperationClaimsModel =
                                                                _mapper.Map<GetListUserOperationClaimsModel>(userOpeationClaim);
            return getListUserOperationClaimsModel;
        }
    }
}

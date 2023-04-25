using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using Core.Security.Entities;
using GameStore.Application.Features.OperationClaims.Models.GetList;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.OperationClaims.Queries.GetList
{
    public class GetListOperationClaimQuery:IRequest<GetListOperationClaimModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, GetListOperationClaimModel>
        {
            private  readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetListOperationClaimModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
              IPaginate<OperationClaim> operationClaims=await _operationClaimRepository.GetListAsync
                                                        (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                GetListOperationClaimModel mappedOperationClaimsModel=_mapper.Map<GetListOperationClaimModel>(operationClaims);
                return mappedOperationClaimsModel;
            }
        }
    }
}

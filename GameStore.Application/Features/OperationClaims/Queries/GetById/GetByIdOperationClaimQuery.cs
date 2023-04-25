using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.OperationClaims.Dtos.GetByIdDto;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.OperationClaims.Queries.GetById
{
    public class GetByIdOperationClaimQuery:IRequest<GetByIdOperationClaimDto>
    {
        public int Id { get; set; }
       
        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, GetByIdOperationClaimDto>
        {
            private readonly IOperationClaimRepository _OperationClaimRepository;
            private readonly IMapper _mapper;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository OperationClaimRepository, IMapper mapper)
            {
                _OperationClaimRepository = OperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdOperationClaimDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _OperationClaimRepository.GetAsync(oc => oc.Id == request.Id);
                GetByIdOperationClaimDto getByIdOperationClaimDto=_mapper.Map<GetByIdOperationClaimDto>(operationClaim);
                return getByIdOperationClaimDto;
            }
        }
    }
}

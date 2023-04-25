using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.UserOperationClaims.Dtos.GetByIdDtos;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.UserOperationClaims.Queries.GetById
{
    public class GetByIdUserOperationClaimQuery:IRequest<GetByIdUserOperationClaimDto>
    {
        public int Id { get; set; }

        public class GetByIdUserOperationClaimQueryHandler : IRequestHandler<GetByIdUserOperationClaimQuery, GetByIdUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;

            public GetByIdUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdUserOperationClaimDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(uoc => uoc.Id == request.Id);
                GetByIdUserOperationClaimDto getByIdUserOperationClaimDto =
                                                        _mapper.Map<GetByIdUserOperationClaimDto>(userOperationClaim);
                return getByIdUserOperationClaimDto;
            }
        }
    }
}

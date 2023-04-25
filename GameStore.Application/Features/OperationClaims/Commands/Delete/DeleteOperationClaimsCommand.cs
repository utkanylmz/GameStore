using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.OperationClaims.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimsCommand:IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimsCommandHandler : IRequestHandler<DeleteOperationClaimsCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;

            public DeleteOperationClaimsCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimsCommand request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim deletedOperationClaim = await _operationClaimRepository.DeleteAsync(mappedOperationClaim);
                DeletedOperationClaimDto deletedOperationClaimDto=_mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);
                return deletedOperationClaimDto;
            }
        }
    }
}

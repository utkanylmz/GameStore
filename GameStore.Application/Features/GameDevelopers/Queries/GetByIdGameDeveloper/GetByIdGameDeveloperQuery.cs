using AutoMapper;
using GameStore.Application.Features.GameDevelopers.Dtos.GetDtos;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Queries.GetByIdGameDeveloper
{
    public class GetByIdGameDeveloperQuery:IRequest<GetByIdGameDeveloperDto>
    {
        public int Id { get; set; }
        public class GetByIdGameDeveloperQueryHandler : IRequestHandler<GetByIdGameDeveloperQuery, GetByIdGameDeveloperDto>
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;

            public GetByIdGameDeveloperQueryHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper)
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdGameDeveloperDto> Handle(GetByIdGameDeveloperQuery request, CancellationToken cancellationToken)
            {
                GameDeveloper gameDeveloper = await _gameDeveloperRepository.GetAsync(gd => gd.Id == request.Id);
                GetByIdGameDeveloperDto dto = _mapper.Map<GetByIdGameDeveloperDto>(gameDeveloper);
                return dto;
            }
        }
        
    }
}

using AutoMapper;
using GameStore.Application.Features.GameTypes.Dtos.GetDto;
using GameStore.Application.Features.GameTypes.Rules;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Queries.GetByIdGameType
{
    public class GetByIdGameTypeQuery:IRequest<GetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdGameTypeQueryHandler:IRequestHandler<GetByIdGameTypeQuery,GetByIdDto>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;
            private readonly GameTypeBusinessRules _gameTypeBusinessRules;
            public GetByIdGameTypeQueryHandler(IGameTypeRepository gameTypeRepository, IMapper mapper,
                GameTypeBusinessRules gameTypeBusinessRules)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
                _gameTypeBusinessRules = gameTypeBusinessRules;
            }

            public async Task<GetByIdDto> Handle(GetByIdGameTypeQuery request, CancellationToken cancellationToken)
            {
                await _gameTypeBusinessRules.CurrentGameTypeIdInfoCheck(request.Id);
                GameType gameType = await _gameTypeRepository.GetAsync(gt=>gt.Id==request.Id);
                GetByIdDto getByIdDto=_mapper.Map<GetByIdDto>(gameType);
                return getByIdDto;
            }
        }
    }
}


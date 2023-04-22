using AutoMapper;
using GameStore.Application.Services.Repositories;
using MediatR;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Application.Features.GameTypes.Dtos.CreateDto;
using GameStore.Application.Features.GameTypes.Rules;
using Core.Application.Pipelines.Logging;

namespace GameStore.Application.Features.GameTypes.Commands.CreateGameType
{
    public class CreateGameTypeCommand:IRequest<CreateGameTypeDto>, ILoggableRequest
    {
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public class CreateGameTypeCommandHandler : IRequestHandler<CreateGameTypeCommand, CreateGameTypeDto>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;
            private readonly GameTypeBusinessRules _gameTypeBusinessRules;

            public CreateGameTypeCommandHandler(IGameTypeRepository gameTypeRepository, IMapper mapper, 
                GameTypeBusinessRules gameTypeBusinessRules)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
                _gameTypeBusinessRules = gameTypeBusinessRules;
            }

            public async Task<CreateGameTypeDto> Handle(CreateGameTypeCommand request, CancellationToken cancellationToken)
            {
                await _gameTypeBusinessRules.GameTypeCanNotDublicateWhenInserted(request.TypeName);
                GameType mappedGameType = _mapper.Map<GameType>(request);
                GameType gameType= await _gameTypeRepository.AddAsync(mappedGameType);
                CreateGameTypeDto createGameTypeDto=_mapper.Map<CreateGameTypeDto>(gameType);
                return createGameTypeDto;
                
            }
        }
    }
}

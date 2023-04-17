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

namespace GameStore.Application.Features.GameTypes.Commands.CreateGameType
{
    public class CreateGameTypeCommand:IRequest<CreateGameTypeDto>
    {
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public class CreateGameTypeCommandHandler : IRequestHandler<CreateGameTypeCommand, CreateGameTypeDto>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;

            public CreateGameTypeCommandHandler(IGameTypeRepository gameTypeRepository, IMapper mapper)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
            }

            public async Task<CreateGameTypeDto> Handle(CreateGameTypeCommand request, CancellationToken cancellationToken)
            {
                GameType mappedGameType = _mapper.Map<GameType>(request);
                GameType gameType= await _gameTypeRepository.AddAsync(mappedGameType);
                CreateGameTypeDto createGameTypeDto=_mapper.Map<CreateGameTypeDto>(gameType);
                return createGameTypeDto;
                
            }
        }
    }
}

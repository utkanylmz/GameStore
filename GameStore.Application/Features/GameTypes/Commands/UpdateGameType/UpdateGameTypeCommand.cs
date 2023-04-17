using AutoMapper;
using GameStore.Application.Features.GameTypes.Dtos.UpdatedDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Commands.UpdateGameType
{
    public class UpdateGameTypeCommand:IRequest<UpdatedGameTypeDto>
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public class UpdateGameTypeCommandHandler : IRequestHandler<UpdateGameTypeCommand, UpdatedGameTypeDto>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;

            public UpdateGameTypeCommandHandler(IGameTypeRepository gameTypeRepository, IMapper mapper)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedGameTypeDto> Handle(UpdateGameTypeCommand request, CancellationToken cancellationToken)
            {
                GameType mappedGameType = _mapper.Map<GameType>(request);
                GameType gameType= await _gameTypeRepository.UpdateAsync(mappedGameType);
                UpdatedGameTypeDto updatedGameTypeDto=_mapper.Map<UpdatedGameTypeDto>(gameType);
                return updatedGameTypeDto;
            }
        }
    }
}

using AutoMapper;
using GameStore.Application.Features.Games.Dtos.CreateDto;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Commands.CreateGame
{
    public class CreateGameCommand:IRequest<CreateGameDto>
    {
        public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreateGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public CreateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public Task<CreateGameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

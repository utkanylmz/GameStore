using AutoMapper;
using GameStore.Application.Features.Games.Dtos.UpdateDto;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommand:IRequest<UpdateGameDto>
    {

        public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, UpdateGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public Task<UpdateGameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
},

using AutoMapper;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Commands.DeleteGame
{
    public class DeleteGameCommand:IRequest<DeleteGameDto>
    {
        public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, DeleteGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public DeleteGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public Task<DeleteGameDto> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

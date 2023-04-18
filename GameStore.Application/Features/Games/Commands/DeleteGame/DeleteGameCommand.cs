using AutoMapper;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
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
        public int Id { get; set; }
        public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, DeleteGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public DeleteGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<DeleteGameDto> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
            {
                Game game = await _gameRepository.GetAsync(g => g.Id == request.Id);
                Game deleteGame = await _gameRepository.DeleteAsync(game);
                DeleteGameDto deleteGameDto=_mapper.Map<DeleteGameDto>(deleteGame);
                return deleteGameDto;
            }
        }
    }
}

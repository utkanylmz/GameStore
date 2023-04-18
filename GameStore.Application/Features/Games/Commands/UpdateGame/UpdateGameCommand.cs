using AutoMapper;
using GameStore.Application.Features.Games.Dtos.UpdateDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameTypeId { get; set; }
        public int GameDeveleporId { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, UpdateGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public UpdateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<UpdateGameDto> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                Game game = new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    GameTypeId = request.GameTypeId,
                    GameDeveleporId = request.GameDeveleporId,
                    Platform = request.Platform,
                    ReleaseDate = Convert.ToDateTime(request.ReleaseDate),
                    Price = request.Price

                };

                Game updatedGame = await _gameRepository.UpdateAsync(game);
                UpdateGameDto updateGameDto=_mapper.Map<UpdateGameDto>(updatedGame);
                return updateGameDto;
            }
        }
    }
}

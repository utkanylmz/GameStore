using AutoMapper;
using GameStore.Application.Features.Games.Dtos.CreateDto;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
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
      
        public string Name { get; set; }
        public int GameTypeId { get; set; }
        public int GameDeveleporId { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreateGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public CreateGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<CreateGameDto> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                Game game = new() {
                   
                    Name = request.Name,
                    GameTypeId = request.GameTypeId ,
                    GameDeveleporId=request.GameDeveleporId,
                    Platform=request.Platform,
                    Price=request.Price,
                    ReleaseDate = Convert.ToDateTime(request.ReleaseDate)

                };

                Game addedGame=await _gameRepository.AddAsync(game);
                CreateGameDto createGameDto=_mapper.Map<CreateGameDto>(game);
                return createGameDto;
            }
        }
    }
}

using AutoMapper;
using GameStore.Application.Features.Games.Dtos.GetDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Queries.GetByIdGame
{
    public class GetByIdGameQuery:IRequest<GetByIdGameDto>
    {
        public int Id { get; set; }
        public class GetByIdQueryHandler : IRequestHandler<GetByIdGameQuery, GetByIdGameDto>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public GetByIdQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdGameDto> Handle(GetByIdGameQuery request, CancellationToken cancellationToken)
            {
                Game game = await _gameRepository.GetAsync(g => g.Id == request.Id);
                GetByIdGameDto getByIdGameDto=_mapper.Map<GetByIdGameDto>(game);
                return getByIdGameDto;
            }
        }
    }
}

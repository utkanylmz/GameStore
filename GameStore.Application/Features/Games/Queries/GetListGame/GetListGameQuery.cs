using AutoMapper;
using GameStore.Application.Features.Games.Models;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Queries.GetListGame
{
    public class GetListGameQuery:IRequest<GetListGameModel>
    {
        public class GetListGameQueryHandler : IRequestHandler<GetListGameQuery, GetListGameModel>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public GetListGameQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public Task<GetListGameModel> Handle(GetListGameQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

using AutoMapper;
using GameStore.Application.Features.Games.Models;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Queries.GetListGameDynamic
{
    public class GetListGameByDynamicQuery:IRequest<GetListGameByDynamicModel>
    {
        public class GetListGameByDynamicQueryHandler : IRequestHandler<GetListGameByDynamicQuery, GetListGameByDynamicModel>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public GetListGameByDynamicQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public Task<GetListGameByDynamicModel> Handle(GetListGameByDynamicQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

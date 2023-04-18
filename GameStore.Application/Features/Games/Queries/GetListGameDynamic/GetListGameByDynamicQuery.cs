using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using GameStore.Application.Features.Games.Models;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Queries.GetListGameDynamic
{
    public class GetListGameByDynamicQuery:IRequest<GetListGameByDynamicModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListGameByDynamicQueryHandler : IRequestHandler<GetListGameByDynamicQuery, GetListGameByDynamicModel>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public GetListGameByDynamicQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<GetListGameByDynamicModel> Handle(GetListGameByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Game> game = await _gameRepository.GetListByDynamicAsync
                                                               (request.Dynamic,
                                                                include:c=>c.Include(gd=>gd.GameDeveloper).Include(gt=>gt.GameType)
                                                               ,size: request.PageRequest.PageSize, 
                                                               index: request.PageRequest.Page, enableTracking: false);
                GetListGameByDynamicModel model=_mapper.Map<GetListGameByDynamicModel>(game);
                return model;
            }       
        }
    }
}

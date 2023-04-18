using AutoMapper;
using Core.Application.Request;
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

namespace GameStore.Application.Features.Games.Queries.GetListGame
{
    public class GetListGameQuery:IRequest<GetListGameModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListGameQueryHandler : IRequestHandler<GetListGameQuery, GetListGameModel>
        {
            private readonly IGameRepository _gameRepository;
            private readonly IMapper _mapper;

            public GetListGameQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<GetListGameModel> Handle(GetListGameQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Game> game= await _gameRepository.GetListAsync(include:g=>g.Include(gt=>gt.GameType).Include(gd=>gd.GameDeveloper),
                                size:request.PageRequest.PageSize,index:request.PageRequest.Page,enableTracking:false);
                GetListGameModel model= _mapper.Map<GetListGameModel>(game);
                return model;
            }
        }
    }
}

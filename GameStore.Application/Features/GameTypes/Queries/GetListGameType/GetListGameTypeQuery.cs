using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Paging;
using GameStore.Application.Features.GameTypes.Model;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Queries.GetListGameType
{
    public class GetListGameTypeQuery:IRequest<GameTypeGetListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGameTypeQueryHandler : IRequestHandler<GetListGameTypeQuery, GameTypeGetListModel>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;

            public GetListGameTypeQueryHandler(IGameTypeRepository gameTypeRepository, IMapper mapper)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
            }

            public async Task<GameTypeGetListModel> Handle(GetListGameTypeQuery request, CancellationToken cancellationToken)
            {
              IPaginate<GameType> gameType=  await _gameTypeRepository.GetListAsync(size: request.PageRequest.PageSize, 
                                                                        index: request.PageRequest.Page,enableTracking: false);
              GameTypeGetListModel typeGetListModel=_mapper.Map<GameTypeGetListModel>(gameType);
                return typeGetListModel;
            }
        }
    }
}

using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
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

namespace GameStore.Application.Features.GameTypes.Queries.GetListGameTypeByDynamic
{
    public class GetListGameTypeByDynamicQuery:IRequest<GetListGameTypeByDynamicModel>
    {
        public Dynamic  Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListGameTypeByDynamicQueryHandler : IRequestHandler<GetListGameTypeByDynamicQuery, GetListGameTypeByDynamicModel>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;

            public GetListGameTypeByDynamicQueryHandler(IGameTypeRepository gameTypeRepository, IMapper mapper)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
            }

            public async Task<GetListGameTypeByDynamicModel> Handle(GetListGameTypeByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GameType> gameTypes = await _gameTypeRepository.GetListByDynamicAsync(request.Dynamic,
                                                          size: request.PageRequest.PageSize, index: request.PageRequest.Page);
                GetListGameTypeByDynamicModel getListGameTypeByDynamicModel=_mapper.Map<GetListGameTypeByDynamicModel>(gameTypes);
                return getListGameTypeByDynamicModel;
            }
        }
    }
}

using AutoMapper;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using GameStore.Application.Features.GameDevelopers.Models;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Queries.GetListGameDeveloperByDynamic
{
    public class GetListGameDeveloperByDynamicQuery:IRequest<GetListGameDeveloperByDynamicModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }
        public class GetListGameDeveloperByDynamicQueryHandler:IRequestHandler<GetListGameDeveloperByDynamicQuery,
                                                                                    GetListGameDeveloperByDynamicModel> 
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;

            public GetListGameDeveloperByDynamicQueryHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper )
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
            }

            public async Task<GetListGameDeveloperByDynamicModel> Handle(GetListGameDeveloperByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GameDeveloper> gameDeveloper= await _gameDeveloperRepository.GetListByDynamicAsync(request.Dynamic,
                                                                 index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                GetListGameDeveloperByDynamicModel model = _mapper.Map<GetListGameDeveloperByDynamicModel>(gameDeveloper);
                return model;
            }
        }
    }
}

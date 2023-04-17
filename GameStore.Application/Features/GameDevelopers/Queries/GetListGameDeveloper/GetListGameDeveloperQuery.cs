using AutoMapper;
using Core.Application.Request;
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

namespace GameStore.Application.Features.GameDevelopers.Queries.GetListGameDeveloper
{
    public class GetListGameDeveloperQuery:IRequest<GetListGameDeveloperModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListGameDeveloperQueryHandler : IRequestHandler<GetListGameDeveloperQuery, GetListGameDeveloperModel>
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;

            public GetListGameDeveloperQueryHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper)
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
            }
            public async Task<GetListGameDeveloperModel> Handle(GetListGameDeveloperQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GameDeveloper> gameDeveloper=await _gameDeveloperRepository.GetListAsync(size: request.PageRequest.PageSize,
                                                    index: request.PageRequest.Page, enableTracking: false);
                GetListGameDeveloperModel model = _mapper.Map<GetListGameDeveloperModel>(gameDeveloper);
                return model;
            }
        }
    }
}

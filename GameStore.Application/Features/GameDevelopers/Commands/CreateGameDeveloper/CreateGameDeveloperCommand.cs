using AutoMapper;
using GameStore.Application.Features.GameDevelopers.Dtos.CreateDtos;
using GameStore.Application.Features.GameDevelopers.Rules;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Commands.CreateGameDeveloper
{
    public class CreateGameDeveloperCommand:IRequest<CreateGameDeveloperDto>
    {
        public string DeveloperCompanyName { get; set; }
        public string DeveloperCompanyMail { get; set; }
        public string DeveloperCompanyCountry { get; set; }

        public class CreateGameDeveloperCommandHandler : IRequestHandler<CreateGameDeveloperCommand, CreateGameDeveloperDto>
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;
            private readonly GameDeveloperBusinessRules _gameDeveloperBusinessRules;

            public CreateGameDeveloperCommandHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper,
                GameDeveloperBusinessRules gameDeveloperBusinessRules = null)
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
                _gameDeveloperBusinessRules = gameDeveloperBusinessRules;
            }

            public async Task<CreateGameDeveloperDto> Handle(CreateGameDeveloperCommand request, CancellationToken cancellationToken)
            {
                await _gameDeveloperBusinessRules.GameDeveloperComponyNameCanNotBeDuplicatedWhenInserted(request.DeveloperCompanyName);
                await _gameDeveloperBusinessRules.GameDeveloperComponyMailCanNotBeDuplicatedWhenInserted(request.DeveloperCompanyMail);
                await _gameDeveloperBusinessRules.GameDeveloperComponyCountryCanNotBeDuplicatedWhenInserted(request.DeveloperCompanyCountry);
               GameDeveloper mappedGameDeveloper=_mapper.Map<GameDeveloper>(request);
                GameDeveloper gameDeveloper=await _gameDeveloperRepository.AddAsync(mappedGameDeveloper);
                CreateGameDeveloperDto createGameDeveloperDto=_mapper.Map<CreateGameDeveloperDto>(gameDeveloper);
                return createGameDeveloperDto;
            }
        }
    }
}

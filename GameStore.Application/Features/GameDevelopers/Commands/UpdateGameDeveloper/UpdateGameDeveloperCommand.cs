using AutoMapper;
using GameStore.Application.Features.GameDevelopers.Dtos.DeleteDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.UpdateDtos;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper
{
    public class UpdateGameDeveloperCommand : IRequest<UpdateGameDeveloperDto>
    {
        public int Id { get; set; }
        public string DeveloperCompanyName { get; set; }
        public string DeveloperCompanyMail { get; set; }
        public string DeveloperCompanyCountry { get; set; }
        public class UpdateGameDeveloperCommandHandler : IRequestHandler<UpdateGameDeveloperCommand, UpdateGameDeveloperDto>
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;

            public UpdateGameDeveloperCommandHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper)
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
            }

            public async Task<UpdateGameDeveloperDto> Handle(UpdateGameDeveloperCommand request, CancellationToken cancellationToken)
            {
                GameDeveloper mappedGameDeveloper = _mapper.Map<GameDeveloper>(request);
                GameDeveloper gameDeveloper = await _gameDeveloperRepository.UpdateAsync(mappedGameDeveloper);
                UpdateGameDeveloperDto updateGameDeveloperDto = _mapper.Map<UpdateGameDeveloperDto>(gameDeveloper);
                return updateGameDeveloperDto;
            }
        }
    }
}

using AutoMapper;
using GameStore.Application.Features.GameDevelopers.Dtos.DeleteDtos;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Commands.DeleteGameDeveloper
{
    public class DeleteGameDeveloperCommand : IRequest<DeleteGameDeveloperDto>
    {
        public int Id { get; set; }
        public class DeleteGameDeveloperCommandHandler : IRequestHandler<DeleteGameDeveloperCommand, DeleteGameDeveloperDto>
        {
            private readonly IGameDeveloperRepository _gameDeveloperRepository;
            private readonly IMapper _mapper;

            public DeleteGameDeveloperCommandHandler(IGameDeveloperRepository gameDeveloperRepository, IMapper mapper)
            {
                _gameDeveloperRepository = gameDeveloperRepository;
                _mapper = mapper;
            }

            public async Task<DeleteGameDeveloperDto> Handle(DeleteGameDeveloperCommand request, CancellationToken cancellationToken)
            {
                GameDeveloper mappedGameDeveloper = await _gameDeveloperRepository.GetAsync(gd => gd.Id == request.Id);
                GameDeveloper gameDeveloper = await _gameDeveloperRepository.DeleteAsync(mappedGameDeveloper);
                DeleteGameDeveloperDto deleteGameDeveloperDto = _mapper.Map<DeleteGameDeveloperDto>(gameDeveloper);
                return deleteGameDeveloperDto;
            }
        }
    }
}

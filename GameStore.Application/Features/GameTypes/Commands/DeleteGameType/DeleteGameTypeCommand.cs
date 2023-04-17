﻿using AutoMapper;
using GameStore.Application.Features.GameTypes.Dtos.DeleteDto;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Commands.DeleteGameType
{
    public class DeleteGameTypeCommand:IRequest<DeleteGameTypeDto>
    {
        public int Id { get; set; }
      

        public class DeleteGameTypeCommandHandler : IRequestHandler<DeleteGameTypeCommand, DeleteGameTypeDto>
        {
            private readonly IGameTypeRepository _gameTypeRepository;
            private readonly IMapper _mapper;
             
            public DeleteGameTypeCommandHandler(IGameTypeRepository gameTypeRepository, IMapper mapper)
            {
                _gameTypeRepository = gameTypeRepository;
                _mapper = mapper;
            }

            public async Task<DeleteGameTypeDto> Handle(DeleteGameTypeCommand request, CancellationToken cancellationToken)
            {
                GameType mappedGameType = await _gameTypeRepository.GetAsync(gt=>gt.Id==request.Id);
                GameType gameType  =await _gameTypeRepository.DeleteAsync(mappedGameType);
                DeleteGameTypeDto deleteGameTypeDto=_mapper.Map<DeleteGameTypeDto>(gameType);
                return deleteGameTypeDto;
            }
        }
    }
}

using Core.Persistence.Paging;
using CrossCuttingConcerns.Exceptions;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Rules
{
    public class GameTypeBusinessRules
    {
        private readonly IGameTypeRepository _gameTypeRepository;

        public GameTypeBusinessRules(IGameTypeRepository gameTypeRepository)
        {
            _gameTypeRepository = gameTypeRepository;
        }

        public async Task GameTypeCanNotDublicateWhenInserted(string number)
        {
            IPaginate<GameType> result = await _gameTypeRepository.GetListAsync(gt => gt.TypeName == number);
            if (result.Items.Any()) throw new BusinessException("Game Type exists");
        }

        public async Task CurrentGameTypeIdInfoCheck(int id)
        {
            IPaginate<GameType> result = await _gameTypeRepository.GetListAsync(gt => gt.Id == id);
            if (result.Items.Any()) throw new BusinessException("No Game Type With Given Id");
        }
    }
}

using Core.Persistence.Paging;
using CrossCuttingConcerns.Exceptions;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Rules
{
    public class GameBusinessRules
    {
        private readonly IGameRepository _gameRepository;

        public GameBusinessRules(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task GameNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Game> result = await _gameRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Game Name exists.");
        }
    }
}

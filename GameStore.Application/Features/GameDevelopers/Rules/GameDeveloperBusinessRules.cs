using Core.Persistence.Paging;
using CrossCuttingConcerns.Exceptions;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Rules
{
    public class GameDeveloperBusinessRules
    {
        private readonly IGameDeveloperRepository _gameDeveloperRepository;

        public GameDeveloperBusinessRules(IGameDeveloperRepository gameDeveloperRepository)
        {
            _gameDeveloperRepository = gameDeveloperRepository;
        }

        public async Task GameDeveloperComponyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<GameDeveloper> result = await _gameDeveloperRepository.GetListAsync(b => b.DeveloperCompanyName == name);
            if (result.Items.Any()) throw new BusinessException("Game Developer Company Name exists.");
        }

        public async Task GameDeveloperComponyMailCanNotBeDuplicatedWhenInserted(string mail)
        {
            IPaginate<GameDeveloper> result = await _gameDeveloperRepository.GetListAsync(b => b.DeveloperCompanyMail == mail);
            if (result.Items.Any()) throw new BusinessException("Game Developer Company Mail exists.");
        }
        public async Task GameDeveloperComponyCountryCanNotBeDuplicatedWhenInserted(string country)
        {
            IPaginate<GameDeveloper> result = await _gameDeveloperRepository.GetListAsync(b => b.DeveloperCompanyCountry == country);
            if (result.Items.Any()) throw new BusinessException("Game Developer Company Country exists.");
        }
    }
}

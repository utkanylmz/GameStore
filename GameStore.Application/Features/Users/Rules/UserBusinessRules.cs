using Core.Persistence.Paging;
using CrossCuttingConcerns.Exceptions;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.FirstName == name);
            if (result.Items.Any()) throw new BusinessException("User name exists.");
        }
    }
}

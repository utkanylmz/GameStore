using Core.Persistence.Paging;
using Core.Security.Entities;
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

        public async Task UserTelNumberCanNotBeDuplicatedWhenInserted(string number)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.TelNumber ==number );
            if (result.Items.Any()) throw new BusinessException("User TelNumber exists.");
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.Email == email);
            if (result.Items.Any()) throw new BusinessException("User EMail exists.");
        }
        public async Task UserNameCanNotBeDuplicatedWhenInserted(string nickName)
        {
            IPaginate<User> result = await _userRepository.GetListAsync(b => b.NickName == nickName);
            if (result.Items.Any()) throw new BusinessException("User EMail exists.");
        }

        public async Task UserMustBeOver18YearsOdlWhenInserted(DateTime birthdate)
        {
            int yas =Convert.ToInt32(DateTime.Now - birthdate);
            if (yas < 18)
            {
                throw new BusinessException("Must be over 18 to register");
            }
        }

        public async Task CurrentIdInfoCheck(int id)
        {
           IPaginate< User> user = await _userRepository.GetListAsync(user => user.Id == id);
            if (user.Items.Any()) throw new BusinessException("No User With Given Id");
        }

    }
}

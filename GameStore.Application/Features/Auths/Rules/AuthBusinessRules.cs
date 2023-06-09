﻿using Core.Security.Entities;
using CrossCuttingConcerns.Exceptions;
using GameStore.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EMailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user =await _userRepository.GetAsync(u=>u.Email == email); 
            if(user != null) { throw new BusinessException("Mail aldready exists"); }
        }
    }
}

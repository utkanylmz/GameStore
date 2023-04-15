using AutoMapper;
using GameStore.Application.Features.Users.Dtos.CreateUser;
using GameStore.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Application.Features.Users.Rules;

namespace GameStore.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<CreatedUserDto>
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }

        public string BirthDate { get; set; }
        public bool IsActive { get; set; }


        public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreatedUserDto>
        {
            private readonly IUserRepository _userRepositories;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            public CreateUserHandler(IUserRepository userRepositories, IMapper mapper, 
                UserBusinessRules userBusinessRules)
            {
                _userRepositories = userRepositories;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }
            public async Task<CreatedUserDto>Handle(CreateUserCommand request,CancellationToken cancellationToken)
            {
                await _userBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.FirstName);
                User mappedUser =new ()
                {
                    FirstName= request.FirstName,
                    LastName= request.LastName,
                    Email= request.Email,
                    TelNumber= request.TelNumber,
                    IsActive= request.IsActive,
                    BirthDate=DateTime.Parse(request.BirthDate)
                };
                User createdUser = await _userRepositories.AddAsync(mappedUser);
                CreatedUserDto createdUserDto=_mapper.Map<CreatedUserDto>(createdUser);
                return createdUserDto;
            }
        }
    }
}

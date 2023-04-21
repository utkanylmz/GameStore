using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.Users.Dtos.DeleteUser;
using GameStore.Application.Features.Users.Rules;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand:IRequest<DeletedUserDto>
    {
        public int Id { get; set; }
        
      

        public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;
            public DeleteUserHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeletedUserDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.CurrentIdInfoCheck(request.Id);

                User mappedUser = await _userRepository.GetAsync(user => user.Id == request.Id);
                User user = await _userRepository.DeleteAsync( mappedUser);
                DeletedUserDto deletedUserDto=_mapper.Map<DeletedUserDto>(user);
                return deletedUserDto;
            }
        }
    }
}

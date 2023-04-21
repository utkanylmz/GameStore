using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.Users.Dtos.UpdatedUser;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserStatusCommand:IRequest<UpdatedUserStatusDto>
    {
       
         public int Id { get; set; }
        public bool IsActive { get; set; }


        public class UptadeUserStatusCommandHandler : IRequestHandler<UpdateUserStatusCommand, UpdatedUserStatusDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UptadeUserStatusCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedUserStatusDto> Handle(UpdateUserStatusCommand request, CancellationToken cancellationToken)
            {
                User mappedUser = await _userRepository.GetAsync(user => user.Id == request.Id);
                mappedUser.IsActive = request.IsActive;
                User returnUser=await _userRepository.UpdateAsync(mappedUser);
                UpdatedUserStatusDto updatedUserStatusDto = _mapper.Map<UpdatedUserStatusDto>(returnUser);
                return updatedUserStatusDto;
               
            }
        }
    }
}

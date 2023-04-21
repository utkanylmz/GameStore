using AutoMapper;
using Core.Security.Entities;
using GameStore.Application.Features.Users.Dtos.CreateUser;
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
    public class UpdateUserCommand:IRequest<UpdatedUserDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TelNumber { get; set; }
        public bool IsActive { get; set; }

        public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdatedUserDto>
        {

            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public UpdateUserHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                User mappedUser = new()
                {
                    Id=request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    TelNumber = request.TelNumber,
                    IsActive = request.IsActive,
                    BirthDate = Convert.ToDateTime(request.BirthDate)
                };
                User user=await _userRepository.UpdateAsync(mappedUser);
                UpdatedUserDto updatedUserDto = _mapper.Map<UpdatedUserDto>(user);
                return updatedUserDto;
            }
        }
    }
}

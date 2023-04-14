using AutoMapper;
using Core.Application;
using GameStore.Application.Features.Users.Dtos.GetByIdUser;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQuery:IRequest<UserGetByIdDto>
    {
        public int  Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
              User user=  await _userRepository.GetAsync(user=>user.Id==request.Id);
              UserGetByIdDto userGetByIdDto=_mapper.Map<UserGetByIdDto>(user);
                return userGetByIdDto;
            }
        }
    }
}

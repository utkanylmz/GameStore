using AutoMapper;
using Core.Application;
using Core.Application.Request;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Core.Security.Entities;
using GameStore.Application.Features.Users.Models.UserListUser;
using GameStore.Application.Services.Repositories;
using GameStore.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Queries.GetListUser
{
    public class GetListUserQuery:IRequest<UserListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListUserQueryHandler:IRequestHandler<GetListUserQuery,UserListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<UserListModel>Handle(GetListUserQuery request,CancellationToken cancellationToken)
            {
              IPaginate<User> users=   await _userRepository.GetListAsync
                                        (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
               UserListModel mappedUserListModel= _mapper.Map<UserListModel>(users);
                return mappedUserListModel;
            }
        }
    }
}

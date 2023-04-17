using AutoMapper;
using Core.Persistence.Paging;

using GameStore.Application.Features.Users.Commands.CreateUser;
using GameStore.Application.Features.Users.Commands.DeleteUser;
using GameStore.Application.Features.Users.Commands.UpdateUser;
using GameStore.Application.Features.Users.Dtos.CreateUser;
using GameStore.Application.Features.Users.Dtos.DeleteUser;
using GameStore.Application.Features.Users.Dtos.GetByIdUser;
using GameStore.Application.Features.Users.Dtos.GetListUser;
using GameStore.Application.Features.Users.Dtos.UpdatedUser;
using GameStore.Application.Features.Users.Models.UserListUser;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            #region Create
            CreateMap<User, CreatedUserDto>().ReverseMap();
            CreateMap<User, CreateUserCommand>().ReverseMap();
            #endregion

            #region List
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<IPaginate<User>, UserListModel>().ReverseMap();
            #endregion

            #region GetById
            CreateMap<User,UserGetByIdDto>().ReverseMap();
            #endregion

            #region Delete
            CreateMap<User,DeletedUserDto>().ReverseMap();
            CreateMap<User,DeleteUserCommand>().ReverseMap();
            #endregion

            #region Update
            CreateMap<User,UpdatedUserDto>().ReverseMap();
            CreateMap<User,UpdateUserCommand>().ReverseMap();
            #endregion

            #region UpdateStatus
            CreateMap<User, UpdateUserStatusCommand>().ReverseMap();
            CreateMap<User,UpdatedUserStatusDto>().ReverseMap();
          
            
            #endregion


        }
    }
}

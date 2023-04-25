using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using GameStore.Application.Features.UserOperationClaims.Commands.Create;
using GameStore.Application.Features.UserOperationClaims.Commands.Delete;
using GameStore.Application.Features.UserOperationClaims.Commands.Update;
using GameStore.Application.Features.UserOperationClaims.Dtos.CreateDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.DeleteDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.GetByIdDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.UpdateDtos;
using GameStore.Application.Features.UserOperationClaims.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region GetList
            CreateMap<IPaginate<UserOperationClaim>, GetListUserOperationClaimsModel>().ReverseMap();
            #endregion


            #region GetById
            CreateMap<UserOperationClaim, GetByIdUserOperationClaimDto>().ReverseMap();
            #endregion


            #region Created
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();
            #endregion


            #region Deleted
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            #endregion


            #region Updated
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimDto>().ReverseMap();
            #endregion
        }
    }
}

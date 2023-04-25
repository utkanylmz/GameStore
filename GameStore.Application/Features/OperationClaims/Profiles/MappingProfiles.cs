using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using GameStore.Application.Features.OperationClaims.Commands.Create;
using GameStore.Application.Features.OperationClaims.Commands.Delete;
using GameStore.Application.Features.OperationClaims.Commands.Update;
using GameStore.Application.Features.OperationClaims.Dtos.CreateDto;
using GameStore.Application.Features.OperationClaims.Dtos.DeleteDto;
using GameStore.Application.Features.OperationClaims.Dtos.GetByIdDto;
using GameStore.Application.Features.OperationClaims.Dtos.UpdateDto;
using GameStore.Application.Features.OperationClaims.Models.GetList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region GetList
              CreateMap<IPaginate<OperationClaim>, GetListOperationClaimModel>().ReverseMap();
            #endregion

            #region GetById
            CreateMap<OperationClaim,GetByIdOperationClaimDto>().ReverseMap();
            #endregion

            #region Create
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim,CreatedOperationClaimDto>().ReverseMap();
            #endregion

            #region Update
            CreateMap<UpdateOperationClaimCommand, OperationClaim>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();
            #endregion

            #region Delete
            CreateMap<DeleteOperationClaimsCommand, OperationClaim>().ReverseMap();
            CreateMap<OperationClaim,DeletedOperationClaimDto>().ReverseMap();
            #endregion
        }
    }
}

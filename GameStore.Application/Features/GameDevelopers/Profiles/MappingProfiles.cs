using AutoMapper;
using Core.Application.Pipelines.Validation;
using Core.Persistence.Paging;
using GameStore.Application.Features.GameDevelopers.Commands.CreateGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Dtos.CreateDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.DeleteDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.GetDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.UpdateDtos;
using GameStore.Application.Features.GameDevelopers.Models;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region CreateMap
            CreateMap<GameDeveloper, CreateGameDeveloperCommand>().ReverseMap();
            CreateMap<GameDeveloper,CreateGameDeveloperDto>().ReverseMap();
            #endregion


            #region UpdateMap
            CreateMap<GameDeveloper,UpdateGameDeveloperCommand>().ReverseMap();
            CreateMap<GameDeveloper,UpdateGameDeveloperDto>().ReverseMap();
            #endregion

            #region DeleteMap
            CreateMap<GameDeveloper,DeleteGameDeveloperDto>().ReverseMap();

            #endregion

            #region GetByIdMap
            CreateMap<GameDeveloper,GetByIdGameDeveloperDto>().ReverseMap();
            #endregion

            #region GetListMap
            CreateMap<IPaginate<GameDeveloper>, GetListGameDeveloperModel>().ReverseMap();
            #endregion

            #region GetByIdByDynamicMap
            CreateMap<IPaginate<GameDeveloper>, GetListGameDeveloperByDynamicModel>().ReverseMap();
            #endregion
        }
    }
}

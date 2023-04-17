using AutoMapper;
using Core.Persistence.Paging;
using GameStore.Application.Features.GameTypes.Commands.CreateGameType;
using GameStore.Application.Features.GameTypes.Commands.DeleteGameType;
using GameStore.Application.Features.GameTypes.Commands.UpdateGameType;
using GameStore.Application.Features.GameTypes.Dtos.CreateDto;
using GameStore.Application.Features.GameTypes.Dtos.DeleteDto;
using GameStore.Application.Features.GameTypes.Dtos.GetDto;
using GameStore.Application.Features.GameTypes.Dtos.UpdatedDto;
using GameStore.Application.Features.GameTypes.Model;
using GameStore.Application.Features.GameTypes.Queries.GetByIdGameType;
using GameStore.Application.Features.GameTypes.Queries.GetListGameType;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region CreateMap
            CreateMap<CreateGameTypeCommand,GameType>().ReverseMap();
            CreateMap<GameType, CreateGameTypeDto>().ReverseMap();
            #endregion

            #region UpdateMap
            CreateMap<GameType, UpdateGameTypeCommand>().ReverseMap();
            CreateMap<GameType, UpdatedGameTypeDto>().ReverseMap();
            #endregion

            #region DeleteMap
            CreateMap<GameType,DeleteGameTypeCommand>().ReverseMap();
            CreateMap<GameType,DeleteGameTypeDto>().ReverseMap();
            #endregion

            #region GetListMap
            CreateMap<IPaginate<GameType>, GameTypeGetListModel>().ReverseMap();
            #endregion

            #region GetListDynamicMap
            CreateMap<IPaginate<GameType>, GetListGameTypeByDynamicModel>().ReverseMap();
            #endregion

            #region GetByIdMap
            CreateMap<GameType, GetByIdDto>().ReverseMap();
            #endregion
        }
    }
}

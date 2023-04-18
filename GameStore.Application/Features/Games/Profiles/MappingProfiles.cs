using AutoMapper;
using Core.Persistence.Paging;
using GameStore.Application.Features.Games.Dtos.CreateDto;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Features.Games.Dtos.GetDto;
using GameStore.Application.Features.Games.Dtos.UpdateDto;
using GameStore.Application.Features.Games.Models;
using GameStore.Application.Features.GameTypes.Dtos.GetDto;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region CreateMap
            CreateMap<CreateGameDto, Game>().ReverseMap();
            #endregion


            #region DeleteMap
            CreateMap<Game, DeleteGameDto>().ReverseMap();
            #endregion

            #region UpdateMap
            CreateMap<UpdateGameDto,Game>().ReverseMap();
            #endregion

            #region GetByIdMap
            CreateMap<GetByIdGameDto, Game>().ReverseMap();
            #endregion

            #region GetListMap
            CreateMap<Game, GetGameListDto>()
                                        .ForMember(gt => gt.GameType, 
                                                    opt => opt.MapFrom(gt => gt.GameType.TypeName))
                                        .ForMember(gd=>gd.GameDevelepor,
                                                    opt=>opt.MapFrom(gd=>gd.GameDeveloper.DeveloperCompanyName))
                                        .ReverseMap();

            CreateMap<IPaginate<Game>, GetListGameModel>().ReverseMap();
            #endregion


            #region GetListByDynamicMap

            CreateMap<Game, GetGameListDynamicDto>()
                                       .ForMember(gt => gt.GameType,
                                                   opt => opt.MapFrom(gt => gt.GameType.TypeName))
                                       .ForMember(gd => gd.GameDevelepor,
                                                   opt => opt.MapFrom(gd => gd.GameDeveloper.DeveloperCompanyName))
                                       .ReverseMap();



            CreateMap<IPaginate<Game>, GetListGameByDynamicModel>().ReverseMap();
            #endregion
        }
    }
}

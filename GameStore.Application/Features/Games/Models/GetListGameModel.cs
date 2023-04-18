using Core.Persistence.Paging;
using GameStore.Application.Features.Games.Dtos.GetDto;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Models
{
    public class GetListGameModel:BasePageableModel
    {
        public IList<GetGameListDto> Items { get; set; }
    }
}

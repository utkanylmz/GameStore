using Core.Persistence.Paging;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Model
{
    public class GameTypeGetListModel:BasePageableModel
    {
        public IList<GameType> Items { get; set; }
    }
}

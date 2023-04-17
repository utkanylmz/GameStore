using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Models
{
    public class GetListGameDeveloperByDynamicModel:BasePageableModel
    {
        public IList<GameDeveloper> Items { get; set; }
    }
}

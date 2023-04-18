using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Dtos.GetDto
{
    public class GetGameListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GameType { get; set; }
        public string GameDevelepor { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Games.Dtos.CreateDto
{
    public class CreateGameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameTypeId { get; set; }
        public int GameDeveleporId { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

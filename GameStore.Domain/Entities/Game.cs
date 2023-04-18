using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class Game:Entity
    {
       

        public string Name { get; set; }
        public int GameTypeId { get; set; }
        public int GameDeveleporId { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        
        public decimal Price { get; set; }

        public virtual GameType? GameType { get; set; }
        public virtual GameDeveloper? GameDeveloper { get; set; }

        public ICollection<User> Users { get; set; }

        public Game()
        {
            
        }

        public Game(int id, string name, int gameTypeId, int gameDeveleporId,
           string platform, DateTime releaseDate, decimal price)
        {
            Id = id;
            Name = name;
            GameTypeId = gameTypeId;
            GameDeveleporId = gameDeveleporId;
            Platform = platform;
            ReleaseDate = releaseDate;
            Price = price;
        }


    }
}

using Core.Persistence;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class UserGame:Entity
    {
        public int UserId { get; set; }
        public int GameId { get; set; }

        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
        public UserGame()
        {
            
        }

        public UserGame(int id,int userId, int gameId)
        {
            Id = id;
            UserId = userId;
            GameId = gameId;
        }
    }
}

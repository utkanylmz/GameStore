using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class GameType:Entity
    {
     
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public ICollection<Game> Games { get; set; }

        public GameType()
        {
            
        }
        public GameType(int id, string typeName, string typeDescription)
        {
            Id = id;
            TypeName = typeName;
            TypeDescription = typeDescription;
        }
    }
}

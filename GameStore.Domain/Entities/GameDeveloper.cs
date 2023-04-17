using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class GameDeveloper:Entity
    {
     

        public string DeveloperCompanyName { get; set; }
        public string DeveloperCompanyMail { get; set; }
        public string DeveloperCompanyCountry { get; set; }
        public ICollection<Game> Games { get; set; }
        public GameDeveloper()
        {
            
        }
        public GameDeveloper(int id,string developerCompanyName, string developerCompanyMail, 
            string developerCompanyCountry)
        {
            Id = id;
            DeveloperCompanyName = developerCompanyName;
            DeveloperCompanyMail = developerCompanyMail;
            DeveloperCompanyCountry = developerCompanyCountry;
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameDevelopers.Dtos.UpdateDtos
{
    public class UpdateGameDeveloperDto
    {
        public int Id { get; set; }
        public string DeveloperCompanyName { get; set; }
        public string DeveloperCompanyMail { get; set; }
        public string DeveloperCompanyCountry { get; set; }
    }
}

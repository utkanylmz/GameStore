using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Dtos.UpdatedDto
{
    public class UpdatedGameTypeDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

       
    }
}

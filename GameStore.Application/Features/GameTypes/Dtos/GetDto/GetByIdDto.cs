using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.GameTypes.Dtos.GetDto
{
    public class GetByIdDto
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
    }
}

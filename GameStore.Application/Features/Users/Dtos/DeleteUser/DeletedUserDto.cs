using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Dtos.DeleteUser
{
    public class DeletedUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TelNumber { get; set; }

        public bool IsActive { get; set; }
    }
}

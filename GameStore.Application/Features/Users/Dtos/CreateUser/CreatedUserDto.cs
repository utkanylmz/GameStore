using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Application.Features.Users.Dtos.CreateUser
{
    public class CreatedUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public  string TelNumber { get; set; }

        public DateTime BirtDate { get; set; }
        public bool IsActive { get; set; }
        public string NickName { get; set; }

    }
}

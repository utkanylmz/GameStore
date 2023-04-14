using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.Entities
{
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TelNumber { get; set; }
      
        public bool IsActive { get; set; }

        public ICollection<Game> Games { get; set; }

        public User()
        {
            
        }
        public User(int id ,string firstName, string lastName, string email,
            DateTime birthDate, string telNumber, bool isActive)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            TelNumber = telNumber;
            IsActive = isActive;
        }
    }
}

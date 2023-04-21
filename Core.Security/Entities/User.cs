using Core.Persistence;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Security.Entities
{
    public class User:Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TelNumber { get; set; }
      
        public bool IsActive { get; set; }
        public string NickName { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
      
        
        //ublic ICollection<Game> Games { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
        }
        public User(int id ,string firstName, string lastName, string email,
            DateTime birthDate, string telNumber, bool isActive,string nickName, 
            byte[] passwordSalt, byte[] passwordHash)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            TelNumber = telNumber;
            IsActive = isActive;
            NickName = nickName;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
        }
    }
}

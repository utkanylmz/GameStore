namespace Core.Security.Dtos
{
    public class UserForRegisterDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string NickName { get; set; }
        public string TelNumber { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}

namespace LoginPage.Api.DTOS.UserDtos
{
    public class CreateUserDto
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; } 
        public string Password { get; set; }
    }
}

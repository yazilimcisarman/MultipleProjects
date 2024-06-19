namespace LoginPage.Api.DTOS.AccountDtos
{
    public class ChangePasswordDto
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        //public string ReNewPassword { get; set; }

    }
}

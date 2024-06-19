namespace LoginPage.Api.DTOS.AccountDtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}

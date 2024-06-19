using Microsoft.AspNetCore.Identity;

namespace LoginPage.Api.Data.Identity
{
    public class AppIdentityUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}

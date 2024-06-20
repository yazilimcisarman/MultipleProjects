using LoginPage.Web.DTOs.AccountDtos;
using Microsoft.AspNetCore.Identity;

namespace LoginPage.Web.Services.AccountServices
{
    public interface IAccountService
    {
        Task<string> LoginAsync(LoginDto dto);
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task LogoutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto dto);
        Task DeleteUserAsync(string userId);
    }
}

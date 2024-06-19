using LoginPage.Api.DTOS.AccountDtos;
using LoginPage.Api.DTOS.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace LoginPage.Api.Services.AccountServices
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

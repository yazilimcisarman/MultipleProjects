using LoginPage.Web.Data.Identity;
using LoginPage.Web.DTOs.AccountDtos;
using LoginPage.Web.Models;
using LoginPage.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LoginPage.Web.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppIdentityUser> _userManager;

        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly IRepository<User> _repository;
        public AccountService(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager, IRepository<User> repository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repository = repository;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user== null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Kullanıcı bulunamadı." });
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, dto.CurrentPassword);
            if (!passwordCheck)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Mevcut şifre yanlış." });
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);

            return result;
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
                var value = await _repository.GetByUserIdAsync(userId);
                await _repository.DeleteAsync(value);
            }

        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return "Kullanıcı bulunamadı.";
            }

            var result = await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return "Giriş başarılı.";
            }
            if (result.IsLockedOut)
            {
                return "Kullanıcı hesabı kilitli.";
            }
            if (result.IsNotAllowed)
            {
                return "Girişe izniniz yok.";
            }
            if (result.RequiresTwoFactor)
            {
                return "İki faktörlü doğrulama gerekli.";
            }

            return "Geçersiz giriş denemesi.";
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            try
            {
                if (dto.Password != dto.RePassword)
                {
                    return IdentityResult.Failed(new IdentityError { Description = "Şifre uyumlu değil." });
                }

                var user = new AppIdentityUser
                {
                    UserName = dto.Email,
                    Email = dto.Email,
                    PhoneNumber = dto.Phone,
                    Firstname = dto.Firstname,
                    Lastname = dto.LastName
                };

                var result = await _userManager.CreateAsync(user, dto.Password);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
    }
}

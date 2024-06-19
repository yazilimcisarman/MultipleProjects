using LoginPage.Api.DTOS.AccountDtos;
using LoginPage.Api.Services.AccountServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _services;

        public AccountsController(IAccountService services)
        {
            _services = services;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _services.LoginAsync(dto);
            if (result == "Giriş başarılı.")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                await _services.RegisterAsync(dto);
                return Ok(new { message = "Kayıt işlemi başarılı." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _services.LogoutAsync();
            return Ok(new { message = "Çıkış işlemi güvenli bir şekilde yapıldı." });
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            var result = await _services.ChangePasswordAsync(dto);
            if (result.Succeeded)
            {
                return Ok(new { message = "Şifre başarılı bir şekilde değiştirildi." });
            }
            return BadRequest(result.Errors);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAccount(string userId)
        {
            await _services.DeleteUserAsync(userId);
            return Ok("Kullanıcı başarılı bir şekilde silindi.");
        }

    }   
}

using LoginPage.Web.DTOs.AccountDtos;
using LoginPage.Web.Services.AccountServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _services;

        public AccountController(IAccountService services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto, string returnUrl = null)
        {
            var value = await _services.LoginAsync(dto);
            if (value == "Giriş başarılı.") 
            {
                if(returnUrl == null)
                {
                    return RedirectToAction("Index","Home");

                }
                return RedirectToAction(returnUrl);
            }
            else
            {
                ViewBag.Login = value;
                return View(dto);
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var value = await _services.RegisterAsync(dto);
            if (value.Succeeded)
            {
                LoginDto dtologin = new LoginDto();
                dtologin.Email = dto.Email;
                dtologin.Password = dto.Password;
                var values = await _services.LoginAsync(dtologin);
                if(values == "Giriş başarılı.")
                {
                    return RedirectToAction("Index", "Home");

                }
                return View(dto);
            }
            else
            {
                ViewBag.Register = value;
                return View(dto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _services.LogoutAsync();
            return RedirectToAction("Login", "Account"); 
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            var value = await _services.ChangePasswordAsync(dto);
            return RedirectToAction("Index", "Home");
        }

    }
}

using LoginPage.Api.DTOS.UserDtos;
using LoginPage.Api.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var values = await _userService.GetAllUserAsync();
            return Ok(values);
        }
        [HttpGet("Id/{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var value = await _userService.GetByIdUserAsync(id);
            return Ok(value);
        }
        [HttpGet("userId/{userId}")]
        public async Task<IActionResult> GetByUserIdUser(string userId)
        {
            var value = await _userService.GetByUserIdAsync(userId);
            return Ok(value);
        }
    }
}

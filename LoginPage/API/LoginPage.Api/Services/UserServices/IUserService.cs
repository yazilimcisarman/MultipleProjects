using LoginPage.Api.DTOS.UserDtos;

namespace LoginPage.Api.Services.UserServices
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUserAsync();
        Task<GetByIdUserDto> GetByIdUserAsync(int id);
        Task CreateUserAsync(CreateUserDto model);
        Task UpdateUserAsync(UpdateUserDto model);
        Task DeleteUserAsync(int id);
        Task<GetByUserIdUserDto> GetByUserIdAsync(string userId);
    }
}

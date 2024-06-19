using LoginPage.Api.DTOS.UserDtos;
using LoginPage.Api.Models;
using LoginPage.Api.Repositories;

namespace LoginPage.Api.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task CreateUserAsync(CreateUserDto model)
        {
            await _repository.CreateAsync(new User
            {
                UserId = model.UserId,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Password =model.Password,
            });
        }

        public async Task DeleteUserAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(values);
        }

        public async Task<List<ResultUserDto>> GetAllUserAsync()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new ResultUserDto
            {
                Id = x.Id,
                UserId = x.UserId,
                Email = x.Email,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Password = x.Password,
            }).ToList();
        }

        public async Task<GetByIdUserDto> GetByIdUserAsync(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdUserDto
            {
                Id = value.Id,
                UserId = value.UserId,
                Email = value.Email,
                Firstname = value.Firstname,
                Lastname = value.Lastname,
                Password = value.Password,
            };
        }

        public async Task<GetByUserIdUserDto> GetByUserIdAsync(string userId)
        {
            var value = await _repository.GetByUserIdAsync(userId);
            return new GetByUserIdUserDto
            {
                Id = value.Id,
                UserId = value.UserId,
                Email = value.Email,
                Firstname = value.Firstname,
                Lastname = value.Lastname,
                Password = value.Password,
            };
        }

        public async Task UpdateUserAsync(UpdateUserDto model)
        {
            var value = await _repository.GetByIdAsync(model.Id);
            value.UserId = model.UserId;
            value.Email = model.Email;
            value.Firstname = model.Firstname;
            value.Lastname = model.Lastname;
            value.Password = model.Password;
            await _repository.UpdateAsync(value);
        }
    }
}

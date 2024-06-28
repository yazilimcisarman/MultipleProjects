using BookLibrary.Api.Dtos;

namespace BookLibrary.Api.Repositories
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}

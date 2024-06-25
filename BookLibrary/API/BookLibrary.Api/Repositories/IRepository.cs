using BookLibrary.Api.Dtos;

namespace BookLibrary.Api.Repositories
{
	public interface IRepository<T> where T : class
	{
		//Task<List<ResultBookDto>> GetAllBooksAsync();
		//Task<GetByIdBookDto> GetByIdBookAsync(int id);
		//Task CreateBookAsync(CreateBookDto model);
		//Task UpdateBookAsync(UpdateBookDto model);

		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}

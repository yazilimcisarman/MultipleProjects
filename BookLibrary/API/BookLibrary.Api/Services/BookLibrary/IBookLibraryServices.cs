using BookLibrary.Api.Dtos;

namespace BookLibrary.Api.Services.BookLibrary
{
	public interface IBookLibraryServices
	{
		Task<List<ResultBookDto>> GetAllBooksAsync();
		Task<GetByIdBookDto> GetByIdBookAsync(int id);
		Task CreateBookAsync(CreateBookDto model);
		Task UpdateBookAsync(UpdateBookDto model);
		Task DeleteBookAsync(int id);
	}
}

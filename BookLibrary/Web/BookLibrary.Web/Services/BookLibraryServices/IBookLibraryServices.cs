using BookLibrary.Web.Dtos;

namespace BookLibrary.Web.Services.BookLibraryServices
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

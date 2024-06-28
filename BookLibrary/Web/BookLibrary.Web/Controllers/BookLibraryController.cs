using BookLibrary.Web.Dtos;
using BookLibrary.Web.Services.BookLibraryServices;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Web.Controllers
{
    public class BookLibraryController : Controller
    {
        private readonly IBookLibraryServices _services;

        public BookLibraryController(IBookLibraryServices services)
        {
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var allBooks = await _services.GetAllBooksAsync();
            var lastTenBooks = allBooks.TakeLast(10).ToList();
            return View(lastTenBooks);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _services.GetByIdBookAsync(id);
            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookDto model)
        {
            await _services.UpdateBookAsync(model);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto model)
        {
            await _services.CreateBookAsync(model);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteBookAsync(id);
            return RedirectToAction("Index", "BookLibrary");
        }
    }
}

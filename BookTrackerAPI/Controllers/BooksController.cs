using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;
using BookTrackerAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allBooks = await _booksService.GetAll();
            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookDTO book)
        {
            await _booksService.AddBookWithAuthor(book);
            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _booksService.GetById(id);
            
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookDTO bookDto)
        {
            var bookModel = await _booksService.Update(id, bookDto);

            if (bookModel == null)
            {
                return NotFound();
            }

            return Ok(bookModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bookModel = await _booksService.Delete(id);

            if (bookModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}

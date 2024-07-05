using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookTrackerAPI.Data;
using BookTrackerAPI.Models;
using BookTrackerAPI.Services.Implementations;
using BookTrackerAPI.Services.Contracts;
using BookTrackerAPI.Models.ViewModels;

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
        public async Task<IActionResult> GetAllBooks()
        {
            var allBooks = await _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _booksService.AddBook(book);
            return Ok(book);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _booksService.GetBookById(id);
            
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, BookDTO bookDto)
        {
            var bookModel = await _booksService.UpdateBook(id, bookDto);

            if (bookModel == null)
            {
                return NotFound();
            }

            return Ok(bookModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel = await _booksService.DeleteBook(id);

            if (bookModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}

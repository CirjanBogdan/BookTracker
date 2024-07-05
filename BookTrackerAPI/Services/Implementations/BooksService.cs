using BookTrackerAPI.Data;
using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;
using BookTrackerAPI.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI.Services.Implementations
{
    public class BooksService : IBooksService
    {
        public ApplicationDbContext _context;

        public BooksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBook(Book bookModel)
        {
            var book = new Book
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
                Author = bookModel.Author,
            };
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateBook(int id, BookDTO bookDto)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = bookDto.Title;
            existingBook.Description = bookDto.Description;
            existingBook.Author = bookDto.Author;

            await _context.SaveChangesAsync();

            return existingBook;
        }

        public async Task<Book?> DeleteBook(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x =>x.Id == id);   

            if (bookModel == null)
            {
                return null;
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }
    }
}

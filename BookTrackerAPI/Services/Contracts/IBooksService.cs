using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;

namespace BookTrackerAPI.Services.Contracts
{
    public interface IBooksService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> AddBook(Book book);
        Task<Book?> GetBookById(int id);
        Task<Book?> UpdateBook(int id, BookDTO bookModel);
        Task<Book?> DeleteBook(int id);
    }
}

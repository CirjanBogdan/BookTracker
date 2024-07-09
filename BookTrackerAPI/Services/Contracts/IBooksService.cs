using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;

namespace BookTrackerAPI.Services.Contracts
{
    public interface IBooksService
    {
        Task<List<BookWithAuthorsDTO>> GetAll();
        Task<BookDTO> AddBookWithAuthor(BookDTO bookModel);
        Task<BookWithAuthorsDTO?> GetById(int id);
        Task<BookDTO?> Update(int id, BookDTO bookModel);
        Task<BookDTO?> Delete(int id);
    }
}

using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;

namespace BookTrackerAPI.Services.Contracts
{
    public interface IAuthorsService
    {
        Task<AuthorDTO?> Add(AuthorDTO author);
        Task<AuthorWithBooksDTO?> GetAuthorWithBooks(int id);
        //Task<Author?> Update(int id, BookDTO bookModel);
        //Task<Author?> Delete(int id);
        //Task<List<Author>> GetAll();
    }
}

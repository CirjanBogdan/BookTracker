using AutoMapper;
using BookTrackerAPI.Data;
using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;
using BookTrackerAPI.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI.Services.Implementations
{
    public class BooksService : IBooksService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BooksService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDTO> AddBookWithAuthor(BookDTO bookModel)
        {
            var book = _mapper.Map<Book>(bookModel);
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            foreach (var id in bookModel.AuthorIds)
            {
                var book_author = new Book_Author
                {
                    BookId = book.Id,
                    AuthorId = id,
                };
                await _context.Book_Authors.AddAsync(book_author);
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<BookDTO>(book);
        }

        public async Task<List<BookWithAuthorsDTO>> GetAll()
        {

            var books = await _context.Books.ToListAsync();
            var booksWithAuthors = _mapper.Map<List<BookWithAuthorsDTO>>(books);

            foreach (var book in booksWithAuthors)
            {
                book.AuthorNames = await _context.Book_Authors.Where(i => i.BookId == book.Id).Select(n => n.Author.FullName).ToListAsync();
            }

            return booksWithAuthors;
        }

        public async Task<BookWithAuthorsDTO?> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return null;
            }
            var bookWithAuthors = _mapper.Map<BookWithAuthorsDTO>(book);

            bookWithAuthors.AuthorNames = await _context.Book_Authors.Where(i => i.BookId == id).Select(n => n.Author.FullName).ToListAsync();

            return bookWithAuthors;
        }

        public async Task<BookDTO?> Update(int id, BookDTO bookDto)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook = _mapper.Map<Book>(bookDto);
            await _context.SaveChangesAsync();

            return bookDto;
        }

        public async Task<BookDTO?> Delete(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(x =>x.Id == id);   

            if (book == null)
            {
                return null;
            }

            var deletedBookModel = _mapper.Map<BookDTO>(book);

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return deletedBookModel;
        }
    }
}

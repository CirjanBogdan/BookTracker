using AutoMapper;
using BookTrackerAPI.Data;
using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;
using BookTrackerAPI.Services.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookTrackerAPI.Services.Implementations
{
    public class AuthorsService : IAuthorsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDTO?> Add(AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);

            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();

            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<AuthorWithBooksDTO?> GetAuthorWithBooks(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            
            var authorWithBooks = _mapper.Map<AuthorWithBooksDTO?>(author);

            authorWithBooks.BookTitles = await _context.Book_Authors.Where(i => i.AuthorId == id).Select(n => n.Book.Title).ToListAsync();

            return authorWithBooks;
        }
    }
}

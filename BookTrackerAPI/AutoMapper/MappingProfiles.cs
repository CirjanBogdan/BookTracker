using AutoMapper;
using BookTrackerAPI.Models;
using BookTrackerAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;

namespace BookTrackerAPI.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookWithAuthorsDTO>().ReverseMap();
            CreateMap<AuthorWithBooksDTO, Author>().ReverseMap();
        }
    }
}

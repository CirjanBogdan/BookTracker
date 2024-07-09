using BookTrackerAPI.Models.ViewModels;
using BookTrackerAPI.Services.Contracts;
using BookTrackerAPI.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorsService _authorsService;

        public AuthorsController(IAuthorsService authorsService)
        {
            _authorsService = authorsService;
        }


        [HttpPost]
        public async Task<IActionResult> Add(AuthorDTO author)
        {
            await _authorsService.Add(author);
            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthorWithBooks(int id)
        {
            var authorsWithBooks = await _authorsService.GetAuthorWithBooks(id);
            
            if (authorsWithBooks == null)
            {
                return NotFound();
            }

            return Ok(authorsWithBooks);
        }
    }
}

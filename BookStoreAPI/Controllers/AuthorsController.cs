using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(Author author)
        {
            var newAuthor = await _authorService.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = newAuthor.Id }, newAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            var result = await _authorService.UpdateAuthor(id, author);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthor(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}

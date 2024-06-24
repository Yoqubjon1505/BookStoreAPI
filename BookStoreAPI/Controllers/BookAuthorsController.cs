using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly BookAuthorService _bookAuthorService;

        public BookAuthorsController(BookAuthorService bookAuthorService)
        {
            _bookAuthorService = bookAuthorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBookAuthors()
        {
            var bookAuthors = await _bookAuthorService.GetBookAuthors();
            return Ok(bookAuthors);
        }

        [HttpGet("{bookId}/{authorId}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(Guid bookId, Guid authorId)
        {
            var bookAuthor = await _bookAuthorService.GetBookAuthor(bookId, authorId);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            return bookAuthor;
        }

        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newBookAuthor = await _bookAuthorService.AddBookAuthor(bookAuthor);
            return CreatedAtAction(nameof(GetBookAuthor), new { bookId = newBookAuthor.BookId, authorId = newBookAuthor.AuthorId }, newBookAuthor);
        }

        [HttpPut("{bookId}/{authorId}")]
        public async Task<IActionResult> PutBookAuthor(Guid bookId, Guid authorId, BookAuthor bookAuthor)
        {
            var result = await _bookAuthorService.UpdateBookAuthor(bookId, authorId, bookAuthor);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{bookId}/{authorId}")]
        public async Task<IActionResult> DeleteBookAuthor(Guid bookId, Guid authorId)
        {
            var result = await _bookAuthorService.DeleteBookAuthor(bookId, authorId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}

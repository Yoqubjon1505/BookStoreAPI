using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Infrastructure;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(BookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooks();

            return Ok( _mapper.Map<IEnumerable<BookDto>>(books));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _bookService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDto book)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _book = _mapper.Map<Book>(book);
            var newBook = await _bookService.AddBook(_book);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid id, BookDto book)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           var _book= _mapper.Map<Book>(book);
            var result = await _bookService.UpdateBook(id, _book);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var result = await _bookService.DeleteBook(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserRepository<Admin> _repository;
        private readonly IMapper _mapper;
        public AdminController(IUserRepository<Admin> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var item = await _repository.GetAsync();

            return Ok(_mapper.Map<IEnumerable<Admin>>(item));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> Create(UserDto entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _entity = _mapper.Map<Admin>(entity);
            var newItem = await _repository.AddAsync(_entity);
            return CreatedAtAction(nameof(Create), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserDto item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _entity = _mapper.Map<Admin>(item);
            var result = await _repository.UpdateAsync(id, _entity);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}

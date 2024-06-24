using AutoMapper;
using BookStoreAPI.DTOs;
using BookStoreAPI.Interfaces.IRepositories;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IUserRepository<Reader> _repository;
        private readonly IMapper _mapper;
        public ReaderController(IUserRepository<Reader> repository, IMapper mapper)
        {
                _repository = repository;
                _mapper = mapper;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var item = await _repository.GetAsync();

            return Ok(_mapper.Map<IEnumerable<Reader>>(item));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Reader>> Create(UserDto intity)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _intity = _mapper.Map<Reader>(intity);
            var newItem = await _repository.AddAsync(_intity);
            return Ok(newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UserDto item)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var _intity = _mapper.Map<Reader>(item);
            var result = await _repository.UpdateAsync(id, _intity);
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

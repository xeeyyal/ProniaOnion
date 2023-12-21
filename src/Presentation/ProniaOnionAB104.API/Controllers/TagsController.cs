﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaApi.Application.DTOs.Category;
using ProniaApi.Application.DTOs.Tag;
using ProniaOnionAB104.Application.Abstractions.Repositories;
using ProniaOnionAB104.Application.Abstractions.Services;

namespace ProniaOnionAB104.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _service;

        public TagsController(ITagService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

        //    return StatusCode(StatusCodes.Status200OK, await _service.GetAsync(id));
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] TagCreateDto tagCreateDto)
        {
            await _service.CreateAsync(tagCreateDto);

            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] TagUpdateDto tagUpdateDto)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, tagUpdateDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaApi.Application.DTOs.Product;
using ProniaOnionAB104.Application.Abstractions.Services;

namespace ProniaOnionAB104.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            return Ok(await _service.GetAllPaginatedAsync(page, take));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetByIsAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productDto)
        {
            await _service.CreateAsync(productDto);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}

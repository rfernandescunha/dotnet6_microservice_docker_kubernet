using GeekShopping.Api.Domain.Dto;
using GeekShopping.Api.Domain.Interfaces.IServices;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GeekShopping.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _services.FindById(id);

            if (result != null)
                return Ok(result);

            return BadRequest("Produto não encontrado.");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _services.FindAll();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDto dto)
        {
            if (dto == null) return BadRequest("Dados do produto é obrigatorio.");

            var result = await _services.Create(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto dto)
        {
            if (dto == null) return BadRequest("Dados do produto é obrigatorio.");

            var result = await _services.Update(dto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _services.Delete(id);

            return Ok(result);
        }
    }
}

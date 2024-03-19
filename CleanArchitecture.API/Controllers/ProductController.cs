using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get()
        {
            var result = await _service.GetProductsAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _service.GeByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ProductDTO request)
        {
            await _service.Add(request);
            return Ok(request);
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductDTO request)
        {
            await _service.Update(request);
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Update(int id)
        {
            await _service.Remove(id);
            return Ok();
        }
    }
}

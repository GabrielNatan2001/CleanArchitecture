using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _service.GeByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductCategory/{id}")]
        public async Task<ActionResult> GetProductCategory(int id)
        {
            var result = await _service.GetProductCategoryAsync(id);
            return Ok(result);
        }
    }
}

using CleanArchitecture.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetCategory()
        {
            var result = await _service.GetCategoriesAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var result = await _service.GeByIdAsync(id);
            return Ok(result);
        }
    }
}

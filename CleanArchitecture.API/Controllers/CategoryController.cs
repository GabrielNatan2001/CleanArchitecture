using CleanArchitecture.Application.DTOs;
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
        public async Task<ActionResult> GetCategory()
        {
            var result = await _service.GetCategoriesAsync();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            var result = await _service.GeByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryDTO request)
        {
            await _service.Add(request);
            return Ok(request);
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryDTO request)
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

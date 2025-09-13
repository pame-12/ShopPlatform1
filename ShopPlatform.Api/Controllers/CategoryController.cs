using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _service.Create(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            if (id != category.CategoryId) return BadRequest();
            _service.Update(category);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int deleteUser)
        {
            _service.Delete(id, deleteUser);
            return Ok();
        }
    }
}


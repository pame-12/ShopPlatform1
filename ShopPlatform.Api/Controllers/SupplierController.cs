using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service) => _service = service;

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _service.Create(supplier);
            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId) return BadRequest();
            _service.Update(supplier);
            return Ok(supplier);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int deleteUser)
        {
            _service.Delete(id, deleteUser);
            return Ok();
        }
    }
}


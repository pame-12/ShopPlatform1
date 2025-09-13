using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service) => _service = service;

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _service.Create(customer);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Customer customer)
        {
            if (id != customer.CustId) return BadRequest();
            _service.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int deleteUser)
        {
            _service.Delete(id, deleteUser);
            return Ok();
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service) => _service = service;

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _service.Create(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.EmpId) return BadRequest();
            _service.Update(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int deleteUser)
        {
            _service.Delete(id, deleteUser);
            return Ok();
        }
    }
}


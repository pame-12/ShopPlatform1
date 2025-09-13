using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _service;

        public ShipperController(IShipperService service) => _service = service;

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());
        [HttpGet("{id}")] public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPost]
        public IActionResult Create(Shipper shipper)
        {
            _service.Create(shipper);
            return Ok(shipper);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Shipper shipper)
        {
            if (id != shipper.ShipperId) return BadRequest();
            _service.Update(shipper);
            return Ok(shipper);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromQuery] int deleteUser)
        {
            _service.Delete(id, deleteUser);
            return Ok();
        }
    }
}

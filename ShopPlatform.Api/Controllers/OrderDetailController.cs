using Microsoft.AspNetCore.Mvc;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _service;

        public OrderDetailController(IOrderDetailService service) => _service = service;

        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{orderId}/{productId}")]
        public IActionResult GetById(int orderId, int productId)
            => Ok(_service.GetById(orderId, productId));

        [HttpPost]
        public IActionResult Create(OrderDetail orderDetail)
        {
            _service.Create(orderDetail);
            return Ok(orderDetail);
        }

        [HttpPut]
        public IActionResult Update(OrderDetail orderDetail)
        {
            _service.Update(orderDetail);
            return Ok(orderDetail);
        }

        [HttpDelete("{orderId}/{productId}")]
        public IActionResult Delete(int orderId, int productId)
        {
            _service.Delete(orderId, productId);
            return Ok();
        }
    }
}


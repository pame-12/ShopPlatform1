using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence;
using ShopPlatform.Persistence.Context;
using System;

namespace ShopPlatform.Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly AppDbContext _context;

        public OrderDetailService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<OrderDetail> GetAll() => _context.OrderDetails.ToList();

        public IEnumerable<OrderDetail> GetByOrder(int orderId) =>
            _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();

        public OrderDetail? GetById(int orderId, int productId) =>
            _context.OrderDetails.Find(orderId, productId);

        public void Create(OrderDetail detail)
        {
          
            var exists = _context.OrderDetails.Find(detail.OrderId, detail.ProductId);
            if (exists != null) throw new InvalidOperationException("Ya existe ese producto en la orden.");

            _context.OrderDetails.Add(detail);
            _context.SaveChanges();
        }

        public void Update(OrderDetail detail)
        {

            var existing = _context.OrderDetails.Find(detail.OrderId, detail.ProductId);
            if (existing == null) return;

            existing.UnitPrice = detail.UnitPrice;
            existing.Qty = detail.Qty;
            existing.Discount = detail.Discount;

            _context.SaveChanges();
        }

        public void Delete(int orderId, int productId)
        {
            var existing = _context.OrderDetails.Find(orderId, productId);
            if (existing == null) return;

            _context.OrderDetails.Remove(existing);
            _context.SaveChanges();
        }
    }
}

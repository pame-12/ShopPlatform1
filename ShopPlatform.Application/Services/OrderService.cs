using System;
using System.Collections.Generic;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Application.Interfaces;
using ShopPlatform.Persistence.Context;


namespace ShopPlatform.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll() => _context.Orders.ToList();

        public Order? GetById(int id) => _context.Orders.Find(id);

        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return;

            var details = _context.OrderDetails.Where(d => d.OrderId == id).ToList();
            if (details.Count > 0)
            {
                _context.OrderDetails.RemoveRange(details);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
}

using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence;
using ShopPlatform.Persistence.Context;
using System;

namespace ShopPlatform.Application.Services
{
    public class ShipperService : IShipperService
    {
        private readonly AppDbContext _context;

        public ShipperService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Shipper> GetAll() => _context.Shippers.ToList();

        public Shipper? GetById(int id) => _context.Shippers.Find(id);

        public void Create(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            _context.SaveChanges();
        }

        public void Update(Shipper shipper)
        {
            _context.Shippers.Update(shipper);
            _context.SaveChanges();
        }

     
        public void Delete(int id, int deleteUser)
        {
            var existing = _context.Shippers.Find(id);
            if (existing == null) return;

            existing.Deleted = true;
            existing.DeleteDate = DateTime.Now;
            existing.DeleteUser = deleteUser;
            _context.SaveChanges();
        }
    }
}

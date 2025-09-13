using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence;
using ShopPlatform.Persistence.Context;

namespace ShopPlatform.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> GetAll() => _context.Suppliers.ToList();

        public Supplier GetById(int id) => _context.Suppliers.Find(id);

        public void Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void Update(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public void Delete(int id, int deleteUser)
        {
            var existing = _context.Suppliers.Find(id);
            if (existing == null) return;

            existing.Deleted = true;
            existing.DeleteDate = DateTime.Now;
            existing.DeleteUser = deleteUser;
            _context.SaveChanges();
        }
    }
}


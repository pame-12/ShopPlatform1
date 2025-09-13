using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence;
using ShopPlatform.Persistence.Context;

namespace ShopPlatform.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll() => _context.Customers.ToList();

        public Customer GetById(int id) => _context.Customers.Find(id);

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id, int deleteUser)
        {
            var existing = _context.Customers.Find(id);
            if (existing == null) return;

            existing.Deleted = true;
            existing.DeleteDate = DateTime.Now;
            existing.DeleteUser = deleteUser;
            _context.SaveChanges();
        }
    }
}

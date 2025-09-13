using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence.Context;

namespace ShopPlatform.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll() => _context.Employees.ToList();

        public Employee GetById(int id) => _context.Employees.Find(id);

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int id, int deleteUser)
        {
            var existing = _context.Employees.Find(id);
            if (existing == null) return;

            existing.Deleted = true;
            existing.DeleteDate = DateTime.Now;
            existing.DeleteUser = deleteUser;
            _context.SaveChanges();
        }
    }
}


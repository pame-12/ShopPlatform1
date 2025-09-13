using ShopPlatform.Application.Interfaces;
using ShopPlatform.Domain.Entities;
using ShopPlatform.Persistence;
using System;
using ShopPlatform.Persistence.Context;

namespace ShopPlatform.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll() => _context.Categories.ToList();

        public Category GetById(int id) => _context.Categories.Find(id);

        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id, int deleteUser)
        {
            var existing = _context.Categories.Find(id);
            if (existing == null) return;

            existing.Deleted = true;
            existing.DeleteDate = DateTime.Now;
            existing.DeleteUser = deleteUser;
            _context.SaveChanges();
        }
    }
}

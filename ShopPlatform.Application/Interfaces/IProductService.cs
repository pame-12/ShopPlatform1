using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id, int deleteUser);
    }
}


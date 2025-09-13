using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        void Create(Supplier supplier);
        void Update(Supplier supplier);
        void Delete(int id, int deleteUser);
    }
}


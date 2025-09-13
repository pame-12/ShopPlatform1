using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(int id, int deleteUser);
    }
}


using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        void Create(Order order);
        void Update(Order order);
        void Delete(int id);
    }
}


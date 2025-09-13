using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail GetById(int orderId, int productId);
        void Create(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(int orderId, int productId);
    }
}


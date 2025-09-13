using ShopPlatform.Domain.Entities;

namespace ShopPlatform.Application.Interfaces
{
    public interface IShipperService
    {
        IEnumerable<Shipper> GetAll();
        Shipper GetById(int id);
        void Create(Shipper shipper);
        void Update(Shipper shipper);
        void Delete(int id, int deleteUser);
    }
}

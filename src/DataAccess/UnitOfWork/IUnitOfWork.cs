using DataAccess.Repository.Interfaces;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        CharacteristicRepository CharacteristicRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        AddressRepository AddressRepository { get; }
        IBrandRepository BrandRepository { get; }
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPackageRepository PackageRepository { get; }

        Task SaveChangesAsync();
    }
}
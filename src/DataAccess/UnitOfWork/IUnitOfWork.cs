using DataAccess.Repository.Interfaces;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        DeliveryRepository DeliveryRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        ICharacteristicRepository CharacteristicRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ProductRepository ProductRepository { get; }
        AddressRepository AddressRepository { get; }
        IBrandRepository BrandRepository { get; }
        OrderDetailsRepository OrderDetailsRepository { get; }
        OrderRepository OrderRepository { get; }
        PackageRepository PackageRepository { get; }

        Task SaveChangesAsync();
    }
}
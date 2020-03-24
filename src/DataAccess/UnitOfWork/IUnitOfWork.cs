using DataAccess.Repository.Interfaces;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        ILikeRepository LikeRepository { get; }
        DeliveryRepository DeliveryRepository { get; }
        ImageRepository ImageRepository { get; }
        ProductCharacteristicRepository ProductCharacteristicRepository { get; }
        CharacteristicRepository CharacteristicRepository { get; }
        CategoryRepository CategoryRepository { get; }
        ProductRepository ProductRepository { get; }
        AddressRepository AddressRepository { get; }
        BrandRepository BrandRepository { get; }
        OrderDetailsRepository OrderDetailsRepository { get; }
        OrderRepository OrderRepository { get; }
        PackageRepository PackageRepository { get; }

        Task SaveChangesAsync();
    }
}
using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IUserRepository UserRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupCharacteristicRepository GroupCharacteristicRepository { get; }

        ICharacteristicRepository CharacteristicRepository { get; }


        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }

        Task SaveChangesAsync();
    }
}
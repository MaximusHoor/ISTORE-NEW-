using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IDeliveryRepository DeliveryRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        Task SaveChangesAsync();
    }
}
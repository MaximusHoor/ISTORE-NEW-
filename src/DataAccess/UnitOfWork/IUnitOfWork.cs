using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IImageRepository ImageRepository { get; }
        IGroupCharacteristicRepository GroupCharacteristicRepository { get; }
        IProductRepository ProductRepository { get; }
        Task SaveChangesAsync();
    }
}
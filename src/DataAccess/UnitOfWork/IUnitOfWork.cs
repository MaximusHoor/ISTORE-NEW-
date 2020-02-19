using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        Task SaveChangesAsync();
    }
}
using Domain.EF_Models;
using Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsAllIncludedAsync();
        Task<Comment> GetCommentAllIncludedAsync(int commentId);
        Task <IEnumerable<Comment>> GetCommentsByUserAsync(int userId);
        Task<IEnumerable<Comment>> GetCommentsByProductAsync(int productId);
        Task<OperationDetail> CreateCommentAsync(Comment comment);
    }
}

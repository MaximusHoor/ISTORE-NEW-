using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
   public interface ICommentService
    {
        Task<IEnumerable<Comment>> FindAllCommentsAsync();
        Task<Comment> FindCommentAsync(int id);
        Task<OperationDetail> CreateCommentAsync(Comment comment);
        Task<OperationDetail> UpdateCommentAsync(Comment comment);
        Task<OperationDetail> DeleteCommentAsync(Comment comment);
    }
}

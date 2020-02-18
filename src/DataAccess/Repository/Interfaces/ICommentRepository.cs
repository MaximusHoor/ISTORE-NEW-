using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.EF_Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Domain.Infrastructure;

namespace DataAccess.Repository.Interfaces
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Task<IEnumerable<Comment>> FindAllCommentsAsync();
        Task<IEnumerable<Comment>> FindCommentByConditionAsync(Expression<Func<Comment, bool>> predicate);
        Task<OperationDetail> CreateCommentAsync(Comment comment);
        Task<OperationDetail> UpdateCommentAsync(Comment comment);
        Task<OperationDetail> DeleteCommentAsync(Comment comment);
    }
}

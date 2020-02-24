using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;

namespace DataAccess.Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> FindAllCommentsAsync();
        Task<Comment> FindCommentByConditionAsync(Expression<Func<Comment, bool>> predicate);
        Task<IEnumerable<Comment>> FindCommentsByConditionAsync(Expression<Func<Comment, bool>> predicate);
        OperationDetail CreateComment(Comment comment);
        OperationDetail UpdateComment(Comment comment);
        OperationDetail DeleteComment(Comment comment);
    }
}
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IReadOnlyCollection<Comment>> GetCommentsAllIncludedAsync();
        Task<IReadOnlyCollection<Comment>> FindByConditionAllIncludedAsync(Expression<Func<Comment, bool>> predicate);
    }
}
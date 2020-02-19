using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(StoreContext context) : base(context)
        {
        }        
        public async Task<IEnumerable<Comment>> FindAllCommentsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<IEnumerable<Comment>> FindCommentByConditionAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await FindByCondition(predicate).ToListAsync();
        }
        public OperationDetail CreateComment(Comment comment)
        {
            return Create(comment);
        }
        public OperationDetail DeleteComment(Comment comment)
        {
            return Delete(comment);
        }
        public OperationDetail UpdateComment(Comment comment)
        {
            return Update(comment);
        }
    }
}
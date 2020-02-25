using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>/*, ICommentRepository*/
    {
        public CommentRepository(StoreContext context) : base(context)
        {
        }
        public override async Task<OperationDetail> CreateAsync(Comment comment)
        {
            return await CreateAsync(comment);
        }

        public async Task<IReadOnlyCollection<Comment>> FindAllCommentsAllIncludedAsync()
        {
            return await this.Entities.Include(x => x.Product).Include(x => x.User).Include(x=>x.Product).ToListAsync();
        }

        public override async Task<IReadOnlyCollection<Comment>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Product).Include(x => x.User).ToListAsync();
        }
        //public async Task<Comment> FindCommentByConditionAsync(Expression<Func<Comment, bool>> predicate)
        //{
        //    return this.Entities.Include(x => x.Product).Include(x => x.User).Include(x => x.Answers).ToListAsync();
        //}

    }
}
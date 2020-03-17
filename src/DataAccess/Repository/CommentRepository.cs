using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
  
        public CommentRepository(StoreContext context) : base(context)
        {
           
        }
        public override async Task<IReadOnlyCollection<Comment>> GetAllAsync()
        {
            return await base.GetAllAsync().ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Comment>> FindByConditionAsync(Expression<Func<Comment, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x=>x.User).Include(x=>x.Product).Include(x=>x.Likes).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsAllIncludedAsync()
        {
            return await this.Entities.Include(x => x.Product).Include(x => x.User).Include(x => x.Answers).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Comment>> FindByConditionAllIncludedAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await this.Entities.Where(predicate).Include(x => x.Product).Include(x => x.User).Include(x => x.Answers).ToListAsync().ConfigureAwait(false);
        }
    }
}
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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context) { }
        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Address).ToListAsync().ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Address).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<User>> FindAllUsersAllIncludedAsync()
        {
            return await this.Entities.Include(x => x.Address).Include(x => x.Comments).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<User>> FindUserByConditionAllIncludedAsync(Expression<Func<User, bool>> userPredicate, Expression<Func<Comment, bool>> commentPredicate)
        {
            return await this.Entities.Where(userPredicate).Include(x => x.Address).Include(x => x.Comments.AsQueryable().Where(commentPredicate)).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<User>> FindUserByConditionAllIncludedAsync(Expression<Func<User, bool>> userPredicate)
        {
            return await this.Entities.Where(userPredicate).Include(x => x.Address).Include(x => x.Comments).ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> GetUserAllIncludedAsync(Expression<Func<User, bool>> userPredicate)
        {
            return await this.Entities.Where(userPredicate).Include(x => x.Address).Include(x => x.Comments).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}

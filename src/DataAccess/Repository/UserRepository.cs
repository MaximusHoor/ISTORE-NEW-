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
    public class UserRepository : BaseRepository<User> /*IUserRepository*/
    {
        public UserRepository(StoreContext context) : base(context) { }
        public override async Task<OperationDetail> CreateAsync(User user)
        {
            return await base.CreateAsync(user);
        }

        public override async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Address).ToListAsync();
        }

        //public async Task<IReadOnlyCollection<User>> FindAllUsersAllIncludedAsync()
        //{
        //    return await this.Entities.Include(x => x.Address).Include(x=>x.Comments).ToListAsync(); 
        //}

        public async Task<IReadOnlyCollection<User>> FindUserByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Address).ToListAsync();
        }

        //public async Task<IReadOnlyCollection<User>> FindUserByConditionAsync(Expression<Func<User, bool>> addressPredicate, Expression<Func<User, bool>> commentPredicate)
        //{
        //    return await this.Entities.Include(addressPredicate).Include(commentPredicate).ToListAsync();
        //}
    }
}

using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(StoreContext context) : base(context) { }
        public OperationDetail CreateUser(User user)
        {
            return Create(user);
        }

        public OperationDetail DeleteUser(User user)
        {
            return Delete(user);
        }

        public async Task<IEnumerable<User>> FindAllUsersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<IEnumerable<User>> FindUserByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await FindByCondition(predicat).ToListAsync();
        }

        public async Task<User> GetUserByConditionAsync(Expression<Func<User, bool>> predicat)
        {
            return await FindByCondition(predicat).FirstOrDefaultAsync();
        }

        public OperationDetail UpdateUser(User user)
        {
            return Update(user);
        }

    }
}

using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IReadOnlyCollection<User>> FindAllUsersAllIncludedAsync();
        Task<IReadOnlyCollection<User>> FindUserByConditionAllIncludedAsync(Expression<Func<User, bool>> userPredicate);
        Task<User> GetUserAllIncludedAsync(Expression<Func<User, bool>> userPredicate);
    }
}

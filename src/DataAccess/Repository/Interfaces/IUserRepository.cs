using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyCollection<User>> FindAllUsersAllIncludedAsync();
        Task<IReadOnlyCollection<User>> FindUserByConditionAsync(Expression<Func<User, bool>> addressPredicate, Expression<Func<User, bool>> commentPredicate);
    }
}

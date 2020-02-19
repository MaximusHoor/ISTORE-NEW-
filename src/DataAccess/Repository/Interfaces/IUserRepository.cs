using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> FindAllUsersAsync();
        Task<IEnumerable<User>> FindUserByConditionAsync(Expression<Func<User, bool>> predicat);
        Task<User> GetUserByConditionAsync(Expression<Func<User, bool>> predicat);
        OperationDetail CreateUser(User user);
        OperationDetail UpdateUser(User user);
        OperationDetail DeleteUser(User user);
    }
}

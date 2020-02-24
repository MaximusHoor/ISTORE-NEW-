using Domain.EF_Models;
using Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
  public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<OperationDetail> CreateUserAsync(User user);
        Task<OperationDetail> UpdateUserAsync(int id, User user);
        Task<OperationDetail> DeleteUserAsync(User user);
    }
}

using Domain.EF_Models;
using Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetUsersAllIncludedAsync();
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUserAllIncludedAsync(int id);
        Task<OperationDetail> CreateUserAsync(User user);
    }
}

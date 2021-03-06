﻿using Domain.EF_Models;
using Domain.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetAllUsersAsync();
        Task<IReadOnlyCollection<User>> GetUsersAllIncludedAsync();
        Task<User> GetUserAsync(string id);
        Task<IReadOnlyCollection<User>> GetUserAllIncludedAsync(string id);
        Task<OperationDetail> CreateUserAsync(User user);
    }
}

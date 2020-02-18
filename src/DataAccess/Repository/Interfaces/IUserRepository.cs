using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.EF_Models;

namespace Domain.Repository.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsers();
    }
}

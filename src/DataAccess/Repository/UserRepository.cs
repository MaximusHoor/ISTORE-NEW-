using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
namespace Domain.Repository
{
    public class UserRepository: BaseRepository<User>,IUserRepository
    {
        public UserRepository(StoreContext context) : base(context)
        {

        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return  FindAll();
        }
    }
}

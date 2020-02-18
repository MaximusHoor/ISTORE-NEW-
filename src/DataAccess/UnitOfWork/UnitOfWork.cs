using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Context;
using Domain.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork
    {
        public UnitOfWork(StoreContext storeContext, IUserRepository userRepository)
        {
            _storeContext = storeContext;
            UserRepository = userRepository;
        }
        private StoreContext _storeContext { get; set; }
        public IUserRepository UserRepository { get; }
        public async Task SaveChangesAsync()
        {
           await _storeContext.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Interfaces;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task SaveChangesAsync();
    } 
}

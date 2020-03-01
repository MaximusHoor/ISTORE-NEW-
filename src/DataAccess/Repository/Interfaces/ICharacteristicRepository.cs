using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ICharacteristicRepository
    {
        Task<Characteristic> GetByIdAsync(int id);
    }
}

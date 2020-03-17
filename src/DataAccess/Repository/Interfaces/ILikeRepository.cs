using Domain.EF_Models;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface ILikeRepository : IRepository<Like>
    {
        Task LikeAsync(Like like);
    }
}
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.Interfaces
{
   public interface ILikeService
    {
        Task ManageLikesAsync(IEnumerable<Like> likes);
    }
}

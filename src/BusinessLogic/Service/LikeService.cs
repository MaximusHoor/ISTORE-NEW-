using Business.Service.Interfaces;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
   public class LikeService:ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikeService(IUnitOfWork unitOfWork) { this._unitOfWork = unitOfWork; }
        public async Task ManageLikesAsync(IEnumerable<Like> likes)
        {
            foreach (var like in likes)
            {
             //   await _unitOfWork.LikeRepository.LikeAsync(like);
            }
            await _unitOfWork.SaveChangesAsync();
        }
    }
}

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
                var _like = await _unitOfWork.LikeRepository.
                 GetLikeAsync(like.UserId,like.ProductId, like.CommentId).ConfigureAwait(false);
                like.Date = DateTime.Now;
                if (_like == null)
                {
                    if (like.IsLikeRemoved) continue;
                    await _unitOfWork.LikeRepository.CreateAsync(like);
                }
                else
                {
                    if (like.IsLiked) await _unitOfWork.LikeRepository.LikeAsync(_like.Id);
                    if (!like.IsLiked) await _unitOfWork.LikeRepository.DislikeAsync(_like.Id);
                    if (like.IsLikeRemoved) await _unitOfWork.LikeRepository.RemoveLikeAsync(_like.Id);
                }
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IReadOnlyCollection<int>> GetLikedCommentsIdAsync(string userId, int productId)
        {
            return await _unitOfWork.LikeRepository.GetLikedCommentsIdAsync(userId, productId);
        }
        public async Task<IReadOnlyCollection<int>> GetDislikedCommentsIdAsync(string userId, int productId)
        {
            return await _unitOfWork.LikeRepository.GetDislikedCommentsIdAsync(userId, productId);
        }
    }
}

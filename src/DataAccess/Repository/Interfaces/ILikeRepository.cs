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
        Task LikeAsync(int id);
        Task RemoveLikeAsync(int id);
        Task DislikeAsync(int id);
        Task<Like> GetLikeByIdAsync(int id);
        Task<Like> GetLikeAsync(string userId, int productId, int commentId);
        Task<IReadOnlyCollection<int>> GetLikedCommentsIdAsync(string userId, int productId);
        Task<IReadOnlyCollection<int>> GetDislikedCommentsIdAsync(string userId, int productId);
        Task DropLikesPhysicallyFromAsync(DateTime date);
    }
}
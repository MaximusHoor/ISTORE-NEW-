using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Repository
{
   public class LikeRepository: BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(StoreContext storeContext) : base(storeContext) { }
        public async Task LikeAsync(int id)
        {
            await this.Entities.Where(x => x.Id == id).
                 UpdateFromQueryAsync(x => new Like { IsLiked = true, IsLikeRemoved = false });
        }
        public async Task DislikeAsync(int id)
        {
            await this.Entities.Where(x => x.Id == id).
                   UpdateFromQueryAsync(x => new Like { IsLiked = false, IsLikeRemoved = false });
        }
        public async Task RemoveLikeAsync(int id)
        {
            await this.Entities.Where(x => x.Id == id).
                 UpdateFromQueryAsync(x => new Like { IsLikeRemoved = true });
        }
        public async Task DropLikesPhysicallyFromAsync(DateTime date)
        {
            await this.Entities.Where(x => x.Date < date && x.IsLikeRemoved == true).
                 DeleteFromQueryAsync();
        }
        public override async Task<IReadOnlyCollection<Like>> FindByConditionAsync(Expression<Func<Like, bool>> predicat)
        {
            return await Entities.Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<int>> GetLikedCommentsIdAsync(string userId, int productId)
        {
            return await Entities.Where(x => x.UserId == userId && x.ProductId == productId && x.IsLiked==true && x.IsLikeRemoved==false).
                Select(x=>x.CommentId).ToListAsync().ConfigureAwait(false);
        }
        public async Task<Like> GetLikeByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
        }
        public async Task<Like> GetLikeAsync(string userId,int productId, int commentId)
        {
            return await Entities.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId && x.CommentId == commentId).ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<int>> GetDislikedCommentsIdAsync(string userId, int productId)
        {
            return await Entities.Where(x => x.UserId == userId && x.ProductId == productId && x.IsLiked == false && x.IsLikeRemoved == false).
                Select(x=>x.CommentId).ToListAsync().ConfigureAwait(false);
        }
    }
}

using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Repository
{
   public class LikeRepository: BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(StoreContext storeContext) : base(storeContext) { }
        public async Task LikeAsync(Like like)
        {
            if (await this.Entities.FindAsync(like.Id) == null)
            {
              if (like.IsLikeRemoved == true) return;
              await this.Entities.AddAsync(new Like 
              { 
                  IsLiked = true, 
                  IsLikeRemoved = false, 
                  CommentId=like.CommentId, 
                  ProductId=like.ProductId,
                  UserId=like.UserId
              });
            } 
            if(like.IsLiked) this.Entities.Where(x => x.Id == like.Id).UpdateFromQuery(x => new Like { IsLiked = true, IsLikeRemoved = false });
            else if (!like.IsLiked)this.Entities.Where(x => x.Id == like.Id).UpdateFromQuery(x => new Like { IsLiked = false, IsLikeRemoved = false });
            else this.Entities.Where(x => x.Id == like.Id).UpdateFromQuery(x => new Like { IsLikeRemoved = true });
        }
    }
}

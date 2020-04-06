using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
  
        public CommentRepository(StoreContext context) : base(context)
        {
           
        }
        public override async Task<IReadOnlyCollection<Comment>> GetAllAsync()
        {
            return await base.GetAllAsync().ConfigureAwait(false);
        }
        public override async Task<IReadOnlyCollection<Comment>> FindByConditionAsync(Expression<Func<Comment, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x=>x.User).Include(x=>x.Product).ToListAsync().ConfigureAwait(false);
        }
        public async Task<IReadOnlyCollection<Comment>> GetCommentsAllIncludedAsync()
        {
            return await this.Entities.Where(x => x.IsRemoved == false).Include(x => x.Product).Include(x => x.User).Include(x => x.Answers).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Comment>> FindByConditionAllIncludedAsync(Expression<Func<Comment, bool>> predicate)
        {
            return await this.Entities.Where(predicate).Include(x => x.Product).Include(x => x.User).Include(x => x.Answers).ToListAsync().ConfigureAwait(false);
        }
        public async Task UpdateCommentLikesAsync(int commentId,int likesTotal, int dislikesTotal)
        {
        //    try
          //  {
               await this.Entities.Where(x => x.Id == commentId).
               UpdateFromQueryAsync(x => new Comment { LikesTotal = likesTotal, DislikesTotal = dislikesTotal }).ConfigureAwait(false);
              // return new OperationDetail() { IsError = false, Message = "Coment's likes updated" };
          //  }
            //catch (Exception e)
            //{
            //    Log.Error(e, "Create Fatal Error");
            //    return new OperationDetail { IsError = true, Message = "Update Likes Total Fatal Error" };
            //}
        }
        public async Task<OperationDetail> UpdateCommentAsync(Comment comment)
        {
            try
            {
            await this.Entities.Where(x => x.Id == comment.Id).
                UpdateFromQueryAsync(x => new Comment
                {
                    IsRemoved = comment.IsRemoved,
                    Raiting = comment.Raiting,
                    Text = comment.Text,
                    Date=comment.Date
                }).ConfigureAwait(false);
                return new OperationDetail() { IsError = false, Message = "Coment updated" };
            }
            catch (Exception e)
            {
                Log.Error(e, "Create Fatal Error");
                return new OperationDetail { IsError = true, Message = "Update Comment Total Fatal Error" };
            }
        }
    }
}
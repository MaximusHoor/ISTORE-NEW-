using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class NewsRepository: BaseRepository<News>
   {
        public NewsRepository(StoreContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<News>> GetAllAsync()
        {
            var res = await this.Entities.ToListAsync().ConfigureAwait(false);
            return res;
        }
        public async Task<News> GetByIdAsync(int id)
        {
            return await _storeContext.News.Where(x => x.Id == id).FirstOrDefaultAsync();            
        }
    }
}

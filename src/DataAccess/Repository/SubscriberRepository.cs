using Domain.Context;
using Domain.EF_Models;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SubscriberRepository : BaseRepository<Subscriber>
    {
        public SubscriberRepository(StoreContext context) : base(context)
        {

        }

        public override async Task<IReadOnlyCollection<Subscriber>> GetAllAsync()
        {
            var res = await this.Entities.ToListAsync().ConfigureAwait(false);
            return res;
        }
    }
}

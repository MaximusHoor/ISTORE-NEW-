using DataAccess.Repository.Interfaces;
using Domain.Context;
using Domain.EF_Models;
using Domain.Infrastructure;
using Domain.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
    

        public ProductRepository(StoreContext context) : base(context)
        {
           
        }  

        public override async Task<IReadOnlyCollection<Product>> GetAllAsync()
        {
            return await this.Entities.Include(br => br.Brand)
                .Include(cat => cat.Category)
                .Include(im => im.Images)
                .Include(pac => pac.Package)
                .Include(grch => grch.GroupCharacteristics).ThenInclude(ch=>ch.Characteristics)
                .Include(com => com.Comments)
                .ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Product>> FindByConditionAsync(Expression<Func<Product, bool>> predicat)
        {
            return await this.Entities.Include(br => br.Brand)
                .Include(cat => cat.Category)
                .Include(im => im.Images)
                .Include(pac => pac.Package)
                .Include(grch => grch.GroupCharacteristics).ThenInclude(ch => ch.Characteristics)
                .Include(com => com.Comments)
                .Where(predicat).ToListAsync().ConfigureAwait(false);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _storeContext.Products.Where(x => x.Id == id)
                .Include(br => br.Brand)
                .Include(cat => cat.Category)
                .Include(im => im.Images)
                .Include(pac => pac.Package)
                .Include(grch => grch.GroupCharacteristics).ThenInclude(ch => ch.Characteristics)
                .Include(com => com.Comments).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<Product>> GetSortByRatingAsync(int count)
        {
            return await _storeContext.Products.OrderByDescending(x => x.Rating).Take(count).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Snap.Core.Entities;
using Snap.Core.Repositories;
using Snap.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Service.Repositories
{
    public class ScrapedProductRepository(SnapDbContext dbContext) : IScrapedProductRepository
    {
        public async Task AddRangeAsync(IEnumerable<ScrapedProduct> products)

        {
            dbContext.ScrapedProducts.AddRange(products);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ScrapedProduct>> GetAllAsync()
      
            => await dbContext.ScrapedProducts.ToListAsync();
       
    }
}

using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Repositories
{
    public interface IScrapedProductRepository
    {
        Task AddRangeAsync(IEnumerable<ScrapedProduct> products);
        Task<List<ScrapedProduct>> GetAllAsync();









    }
}

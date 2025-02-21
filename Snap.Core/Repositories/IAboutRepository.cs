using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Repositories
{
    public interface IAboutRepository
    {


        Task<Entities.About> GetByUserIdAsync(string userId);
        Task<IEnumerable<Entities.About>> GetAllAsync();
        Task<Entities.About> CreateAsync(Entities.About about);

        Task<Dictionary<string, IEnumerable<string>>> GetEnumChoicesAsync();
        public  Task SaveChangesAsync();
    }
}

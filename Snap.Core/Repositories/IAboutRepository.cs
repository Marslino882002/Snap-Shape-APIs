using Snap.Core.Constants;
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


        public Task<int> AddAsync(Entities.About term);
        //public Task DeleteAsync(int id);
        //public Task<List<Entities.About>> GetAllAsync(Global.ChronicDisease type);

        //public Task Update(Entities.About term);
        public  Task SaveChangesAsync();
    }
}

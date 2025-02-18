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


        Task<About> GetAboutByUserId(string userId);
        Task<bool> CreateOrUpdateAbout(About about);


    }
}

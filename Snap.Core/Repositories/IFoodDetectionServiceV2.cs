using Microsoft.AspNetCore.Http;
using Snap.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Repositories
{
    public interface IFoodDetectionServiceV2
    {

        Task<FoodDetectionResultV2Dto> DetectAsync(IFormFile imageFile);






    }
}

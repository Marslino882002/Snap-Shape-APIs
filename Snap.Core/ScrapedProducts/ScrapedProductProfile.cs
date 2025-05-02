using AutoMapper;
using Snap.Core.DTOs;
using Snap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.ScrapedProducts
{
    public class ScrapedProductProfile : Profile
    {
        public ScrapedProductProfile()
        {
            CreateMap<ScrapedProduct, ScrapedProductDto>();
        }
    }
}

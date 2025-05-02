using MediatR;
using Snap.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.ScrapedProducts.Queries
{
    public class GetScrapedProductsQuery : IRequest<List<ScrapedProductDto>>
    {

    }
}

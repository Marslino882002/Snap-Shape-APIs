using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.ScrapedProducts.Commands.ScrapeHealthyProducts
{
    public class ScrapeHealthyProductsCommand : IRequest<int>
    {


        public string CategoryUrl { get; set; }



    }
}

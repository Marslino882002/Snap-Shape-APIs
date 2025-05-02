using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.DTOs
{
    public class ScrapedProductDto
    {

        public string Title { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime ScrapedAt { get; set; }

    }
}

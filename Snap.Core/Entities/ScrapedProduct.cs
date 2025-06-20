using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.Entities
{
    public class ScrapedProduct
    {


        public int Id { get; set; }

        public string Title { get; set; }        // Use either Title OR Name
        public string Url { get; set; }
        public string ImageUrl { get; set; }

        public decimal Price { get; set; }       // Keep this one
        public string Category { get; set; }

        public DateTime ScrapedAt { get; set; }  // Good to track scraping time
    }
}
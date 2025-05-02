using HtmlAgilityPack;
using MediatR;
using Snap.Core.Entities;
using Snap.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snap.Core.ScrapedProducts.Commands.ScrapeHealthyProducts
{
    public class ScrapeHealthyProductsCommandHandler(IScrapedProductRepository _repo) : IRequestHandler<ScrapeHealthyProductsCommand, int>
    {
        public async Task<int> Handle(ScrapeHealthyProductsCommand request, CancellationToken cancellationToken)
        {



            var http = new HttpClient();
            var html = await http.GetStringAsync(request.CategoryUrl);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = new List<ScrapedProduct>();
            var items = doc.DocumentNode.SelectNodes("//li[contains(@class,'type-product')]");


            if (items != null)
            {
                foreach (var item in items)
                {
                    var linkNode = item.SelectSingleNode(".//h2[@class='woocommerce-loop-product__title']/a");
                    var imgNode = item.SelectSingleNode(".//img[contains(@class,'zoomable_img')]");
                    var priceNode = item.SelectSingleNode(".//span[@class='price']//bdi");

                    var title = linkNode?.InnerText.Trim() ?? string.Empty;
                    var url = linkNode?.GetAttributeValue("href", string.Empty) ?? string.Empty;
                    var img = imgNode?.GetAttributeValue("src", string.Empty) ?? string.Empty;
                    var priceText = priceNode?.InnerText.Trim().Replace("ر.س", "").Replace("EGP", "").Trim() ?? "0";
                    decimal.TryParse(priceText, out var price);

                    products.Add(new ScrapedProduct
                    {
                        Title = title,
                        Url = url,
                        ImageUrl = img,
                        Price = price,
                        Category = request.CategoryUrl,
                        ScrapedAt = DateTime.UtcNow
                    });
                }
            }
            if (products.Count > 0)
                await _repo.AddRangeAsync(products);

            return products.Count;













        }
    }
}

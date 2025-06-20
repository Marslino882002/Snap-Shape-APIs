using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using Snap.Core.Entities;
using Snap.Core.Repositories;
using Snap.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Snap.Core.DTOs;

namespace Snap.Service.Repositories
{
    public class ScrapedProductRepository(SnapDbContext dbContext) : IScrapedProductRepository
    {
        public async Task AddRangeAsync(IEnumerable<ScrapedProduct> products)

        {
            dbContext.ScrapedProducts.AddRange(products);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<ScrapedProduct>> GetAllAsync()
      
            => await dbContext.ScrapedProducts.ToListAsync();

        public async Task<List<ScrapedProduct>> ScrapeFromUrlAsync(string categoryUrl)
        {

            var products = new List<ScrapedProduct>();

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.GotoAsync(categoryUrl);

            // Wait for product container to load
            await page.WaitForSelectorAsync(".product-cell-container");

            // Scrape product data with JavaScript evaluation
            var jsProducts = await page.EvaluateAsync(@"() => {
        return [...document.querySelectorAll('.product-cell-container')].map(card => {
            const title = card.querySelector('.product-title a')?.textContent?.trim();
            const priceText = card.querySelector('.price span')?.textContent?.trim()?.replace('$', '').replace(',', '');
            const price = parseFloat(priceText) || 0;
            const image = card.querySelector('img')?.src;
            return { title, price, image };
        });
    }");

            var json = jsProducts?.ToString();
            var rawList = JsonSerializer.Deserialize<List<ScrapedProductDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            foreach (var item in rawList)
            {
                if (!string.IsNullOrEmpty((string)item.Title))
                {
                    products.Add(new ScrapedProduct
                    {
                        Title = item.Title,
                        Price = (decimal)item.Price,
                        ImageUrl = item.ImageUrl
                    });
                }
            }

            return products;











        }
    }
}

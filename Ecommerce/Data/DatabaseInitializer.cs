using Ecommerce.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class DatabaseInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;

                var db = scopeServiceProvider.GetService<MySqlDbContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await Seed(scopeServiceProvider);
                }
            }
        }
        private static async Task Seed(IServiceProvider serviceProvider)
        {
            var products = new Product[]
             {
                new Product{ Name="iphone 6",Price=5000,StockQty=10 },
                new Product{ Name="iphone 7",Price=6000,StockQty=10 },
                new Product{ Name="iphone 7 plus",Price=7000,StockQty=10 },
                new Product{ Name="iphone x",Price=8000,StockQty=10 }
             };


            var db = serviceProvider.GetService<MySqlDbContext>();

            db.Products.AddRange(products);

            await db.SaveChangesAsync();
        }
    }
}

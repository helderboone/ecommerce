using Ecommerce.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Context
{
    public class DatabaseInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;

                var db = scopeServiceProvider.GetService<DatabaseContext>();

                if (await db.Database.EnsureCreatedAsync())
                {
                    await Seed(scopeServiceProvider);
                }
            }
        }

        private static async Task Seed(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<DatabaseContext>();

            var categories = new Category[]
             {
                new Category{ Name="Electronic" },
             };

            db.Categories.AddRange(categories);

            var linesAffected = await db.SaveChangesAsync();

            var products = new Product[]
             {
                new Product{ Name="iphone 6", Description = "Iphone 6" , Category = categories[0] },
                new Product{ Name="iphone 7", Description = "Iphone 7" , Category = categories[0] },
                new Product{ Name="iphone 7 plus", Description = "iphone 7 plus" , Category = categories[0] },
                new Product{ Name="iphone x", Description = "iphone x" , Category = categories[0] },
             };

            db.Products.AddRange(products);

            await db.SaveChangesAsync();

            db.Dispose();
        }
    }
}

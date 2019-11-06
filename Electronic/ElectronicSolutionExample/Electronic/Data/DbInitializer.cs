using Electronic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic.Data
{
    public class DbInitializer
    {
        public static void Initialize(ItemContext context)
        {
            context.Database.EnsureCreated();

            // Look for any items.
            if (context.Items.Any())
            {
                return;   // DB has been seeded
            }

            var items = new Item[]
            {
                new Item{Id=1,Name="iPhone 8 64GB",Description="sort",Price=5000,Rating=3.7},
                new Item{Id=2,Name="iPhone 11 64GB",Description="sort",Price=3000,Rating=3.5},
                new Item{Id=3,Name="iPhone XR 64GB",Description="sort",Price=6500,Rating=4.7},
                new Item{Id=4,Name="iPhone 8 64GB",Description="guld",Price=1500,Rating=3.9},
                new Item{Id=5,Name="iPhone 7 32GB",Description="sort",Price=4100,Rating=4.9},
                new Item{Id=6,Name="iPhone 6s 32GB",Description="space grey",Price=1900,Rating=5}
            };
            foreach (Item s in items)
            {
                context.Items.Add(s);
            }
            context.SaveChanges();
        }
    }
}

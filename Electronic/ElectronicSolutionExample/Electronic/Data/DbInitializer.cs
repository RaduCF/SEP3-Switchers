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
            /*if (context.Items.Any())
            {
                return;   // DB has been seeded
            }*/

            var items = new Item[]
            {
                new Item{Id=1,Name="iphone 8 64gb",Description="sort",Price=5000,Rating=3.7},
                new Item{Id=2,Name="iphone 11 64gb",Description="sort",Price=3000,Rating=3.5},
                new Item{Id=3,Name="iphone XR 64gb",Description="sort",Price=6500,Rating=4.7},
                new Item{Id=4,Name="iphone 8 64gb",Description="guld",Price=1500,Rating=3.9},
                new Item{Id=5,Name="iphone 7 32gb",Description="sort",Price=4100,Rating=4.9},
                new Item{Id=6,Name="iphone 6s 32gb",Description="space grey",Price=1900,Rating=5}
            };
            foreach (Item s in items)
            {
                context.Items.Update(s);
            }
            context.SaveChanges();
        }

        /*protected override void Seed(Electronic.Data.ItemContext context)
        {
            context.Students.AddOrUpdate(
            s => s.LastName,
            new Student
            {
                StudentID = 12345678,
                FirstMidName = "Carson",
                LastName = "Arturo"
            }, );
        }*/
    }
}

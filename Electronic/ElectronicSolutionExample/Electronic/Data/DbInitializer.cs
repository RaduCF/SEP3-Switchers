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
                new Item{Id=1,Title="Sony Xperia L3 mobiltelefon - sort",URL="https://www.bilka.dk/elektronik/mobiltelefoner/alle-mobiltelefoner/sony-xperia-l3-mobiltelefon---sort/p/100474116",ImageURL="https://sg-next.imgix.net/medias/sys_master/root/hc9/hbb/11513048694814.png?h=175&auto=format&fm=jpg",Price=1440,PriceCurrency="dkk",Rating=3},
                new Item{Id=2,Title="Sony Xperia 10 mobiltelefon",URL="https://www.bilka.dk/elektronik/mobiltelefoner/alle-mobiltelefoner/sony-xperia-10-mobiltelefon/p/100474117",ImageURL="https://sg-next.imgix.net/medias/sys_master/root/h50/h2f/11541975302174/SM13-group-black.png?h=175&auto=format&fm=jpg",Price=2628,PriceCurrency="dkk",Rating=3},
                new Item{Id=3,Title="Sony Xperia 10 Plus mobiltelefon",URL="https://www.bilka.dk/elektronik/mobiltelefoner/alle-mobiltelefoner/sony-xperia-10-plus-mobiltelefon/p/100474122",ImageURL="https://sg-next.imgix.net/medias/sys_master/root/hf7/h53/11543463919646/SM23-group-black.png?h=175&auto=format&fm=jpg",Price=3235,PriceCurrency="dkk",Rating=3},
                new Item{Id=4,Title="Sony Xperia 5 mobiltelefon",URL="https://www.bilka.dk/elektronik/mobiltelefoner/alle-mobiltelefoner/sony-xperia-5-mobiltelefon/p/100508135",ImageURL="https://sg-next.imgix.net/medias/sys_master/root/ha7/h44/13289646325790/1-88622641-SONY-XPERIA-5-NORDIC-EDITION-DS-BL-.jpg?h=175&auto=format&fm=jpg",Price=5999,PriceCurrency="dkk",Rating=3},
                new Item{Id=5,Title="Sony Xperia 1 J99910",URL="https://www.bilka.dk/elektronik/mobiltelefoner/alle-mobiltelefoner/sony-xperia-1-j99910/p/100487327",ImageURL="https://sg-next.imgix.net/medias/sys_master/root/hd3/hae/11887011921950/4-pf13-groupBF40-Gray-wo-clock.png?h=175&auto=format&fm=jpg",Price=6669,PriceCurrency="dkk",Rating=3},
                /*new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},
                new Item{Id=1,Name="iphone 8 64gb",URL="sort",ImageURL="",Price=5000,PriceCurrency="",Rating=3.7},*/
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

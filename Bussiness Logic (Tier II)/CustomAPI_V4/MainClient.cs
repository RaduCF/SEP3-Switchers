using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAPI_V4
{
    class MainClient
    {
        

        public static void Main(string[] args)
        {
            var gClient = new GoogleClient();
            var electronic = new Electronic();

            foreach (var Item in gClient.searchApi("iphone"))
            {
                Console.WriteLine($"Title= {Item.Title}\nLink={Item.Link}");
                foreach (var i in Item.Pagemap.Offer)
                {
                    Console.WriteLine($"Price= {Item.Pagemap.Offer[0].Price} {Item.Pagemap.Offer[1].Pricecurrency}");
                }
            }
            foreach (var Item in electronic.getElectronicList("iphone"))
            {
                Console.WriteLine(Item);
            }
        }
    }
}

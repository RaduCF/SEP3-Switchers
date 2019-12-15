using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomAPI_V4
{
    public class CompareIT
    {
        public List<Item> GoogleList { get; set; }
        public GoogleClient GoogleClient = new GoogleClient();

        // public List<Item> ElectronicList { get; set; } Claire

        public /*async*/ IEnumerable<Item> SearchForItems(string searchInput)
        {
            GoogleList = GoogleClient.searchApi(searchInput);

            return GoogleList;
        }
        public List<Item> SortedPriceList(string searchItem)
        {
            List<Item> everything = GoogleClient.searchApi(searchItem);
            List<Item> sortedlist = new List<Item>();
            int size = 0;

            foreach (var priceditem in everything)
            {
                if (priceditem.Pagemap.Offer != null)
                {
                    size++;
                }
            }

            Item[] itemswithprice = new Item[size];

            try
            {
                var index = 0;
                foreach (var priceditem in everything)
                {
                    if (priceditem.Pagemap.Offer != null)
                    {
                        itemswithprice[index] = priceditem;
                        index++;
                    }
                }
                //start of sorting
                int i, j;
                int N = itemswithprice.Length;

                for (j = N - 1; j > 0; j--)
                {
                    for (i = 0; i < j; i++)
                    {
                        if (itemswithprice.ElementAt(i).Pagemap.Offer[0].Price > itemswithprice.ElementAt(i + 1).Pagemap.Offer[0].Price)
                        {
                            var temp = itemswithprice[i];
                            itemswithprice[i] = itemswithprice[i + 1];
                            itemswithprice[i + 1] = temp;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            foreach (var item in itemswithprice)
            {
                Console.WriteLine(item.Title + " and the price: " + item.Pagemap.Offer[0].Price);
            }
            return itemswithprice.ToList<Item>();
        }
    }
}

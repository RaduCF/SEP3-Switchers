using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAPI_V4
{
    public class CompareIT
    {
        public List<Item> GoogleList { get; set; }
        public GoogleClient GoogleClient = new GoogleClient();
        public List<Item> ElectronicList { get; set; }
        public Electronic Electronic = new Electronic();

        public async Task<IEnumerable<Item>> SearchForItems(string searchInput)
        {
            GoogleList = await GoogleClient.searchApi(searchInput);

            return GoogleList;
        }

        public async Task<IEnumerable<FinalItem>> SearchItemsName(string searchInput)
        {
            var items = await Electronic.GetItemsName(searchInput);
            return items;

        }
        public List<FinalItem> SortedPriceList(string searchItem)
        {
            List<Item> elgigantenlist = GoogleClient.searchApi(searchItem).Result;
            List<FinalItem> everything = new List<FinalItem>();

            foreach (var eitem in elgigantenlist)
            {
                FinalItem newitem = new FinalItem { Title=eitem.Title, URL=eitem.Link.ToString(), ImageURL=null, Price=eitem.Pagemap.Offer[0].Price, PriceCurrency=eitem.Pagemap.Offer[0].Pricecurrency, Rating=eitem.Pagemap.Aggregaterating[0].Ratingvalue };
                everything.Add(newitem);
            }
            List<FinalItem> bilka = (List<FinalItem>)SearchItemsName(searchItem).Result;

            foreach (var bitem in bilka)
            {
                FinalItem newitem = new FinalItem { Title = bitem.Title, URL = bitem.URL, ImageURL = bitem.ImageURL, Price = bitem.Price, PriceCurrency = bitem.PriceCurrency, Rating = bitem.Rating };
                everything.Add(newitem);
            }

            int size = everything.Count;
            FinalItem[] itemswithprice = new FinalItem[size];
            List<Item> sortedlist = new List<Item>();
            try
            {
                var index = 0;
                foreach (var allitem in everything)
                {
                    if (allitem != null)
                    {
                        itemswithprice[index] = allitem;
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
                        if (itemswithprice.ElementAt(i).Price > itemswithprice.ElementAt(i + 1).Price)
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
                Console.WriteLine(item.Title + " and the price: " + item.Price);
            }
            return itemswithprice.ToList<FinalItem>();
        }
    }
}

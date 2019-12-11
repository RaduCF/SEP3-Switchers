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

        public List<Item> ElectronicList { get; set; }

        public Electronic Electronic = new Electronic();

        public /*async*/ IEnumerable<Item> SearchForItems(string searchInput)
        {
            GoogleList = GoogleClient.searchApi(searchInput);

            return GoogleList;
        }

        public IEnumerable<SomethingElectronic> SearchItemsName(string searchInput)
        {
            IEnumerable<SomethingElectronic> list = new List<SomethingElectronic>();

            var items = Electronic.GetItemsName(searchInput);

            foreach (var item in items.Result)
            {
                list.Append(item);
            }
            return list;

        }
        public List<Item> SortedPriceList(string searchItem)
        {
            List<Item> everything = GoogleClient.searchApi(searchItem);
            List<Item> sortedlist = new List<Item>();
            List<SomethingElectronic> bilka = (List<SomethingElectronic>)SearchItemsName(searchItem);
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

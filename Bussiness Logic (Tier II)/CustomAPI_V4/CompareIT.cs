using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAPI_V4
{
    public class CompareIT
    {
        public List<Item> GoogleList{ get; set; }
        public GoogleClient GoogleClient= new GoogleClient();

       // public List<Item> ElectronicList { get; set; } Claire

       public /*async*/ List<Item> SearchForItems(string searchInput)
       {
            GoogleList = GoogleClient.searchApi(searchInput);
            return GoogleList;
       }

       public List <Item>  SortedPriceList(string searchItem)
        {
            var everything = SearchForItems(searchItem);
            List<Item> thecheapestfirst = new List<Item>();
            List<long> cheapItem = new List<long>();
            try
            {
                foreach (var items in everything)
                {
                    if (items.Pagemap.Offer != null)
                    {
                        //get the price 
                        var price = items.Pagemap.Offer[0].Price;
                        for (int j = everything.Count - 1; j > 0; j--)
                        {
                            for (int i = 0; i < j; i++)
                            {
                                if (items.Pagemap.Offer[i].Price > items.Pagemap.Offer[i + 1].Price)
                                {
                                    var temp = everything[j - 1];
                                    everything[j - 1] = everything[j];
                                    everything[j] = temp;
                                }
                            }
                        }
                        //  cheapItem.Add(price);

                    }

                }
               // cheapItem.Sort();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return everything;

        }
    }
}

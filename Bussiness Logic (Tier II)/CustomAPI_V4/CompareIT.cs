using System;
using System.Collections.Generic;
using System.Linq;
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

      /*  public List<long> LowPrice(String SearchInput)
        {
            var everything = SearchForItems(SearchInput);
            List<long> cheapItem = new List<long>();
            try
            {
                foreach (var items in everything)
                {
                    if (items.Pagemap.Offer != null)
                    {
                        //get the price 
                        var price = items.Pagemap.Offer[0].Price;
                        cheapItem.Add(price);

                    }

                }
                cheapItem.Sort();
            }
            catch(Exception e) 
            {
                Console.WriteLine(  e.StackTrace);
                        }
            return cheapItem;
        }*/

        
    }
}

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

       public /*async*/ IEnumerable<Item> SearchForItems(string searchInput)
       {
            GoogleList = GoogleClient.searchApi(searchInput);

            return GoogleList;
       }
    }
}

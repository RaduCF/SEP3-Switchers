using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomAPI_V4;

namespace CompareIT_API.Model
{
    public class TodoItem
    {
        public List<Item> GoogleList { get; set; }
        public GoogleClient GoogleClient = new GoogleClient();
        public long Id { get; set; }
            public string Title { get; set; }
            public long Price { get; set; }

            public /*async*/ List<Item> SearchForItems(string searchInput)
            {
                GoogleList = GoogleClient.searchApi(searchInput);

                return GoogleList;
            }

    }
}


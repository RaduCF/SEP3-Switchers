using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Connection
    {

        public List<Item> Final { get; set; } = new List<Item>();

        public void GetItems(string search)
        {
            if (!search.Equals(null))
            {
                Final.Clear();

                string resultstring;
                var itemname = search;
                RestClient client = new RestClient("https://localhost:5001/api/TodoItems/");
                RestRequest request = new RestRequest(Method.POST);
                request.AddParameter("title", itemname);

                IRestResponse response = client.Execute(request);
                resultstring = response.Content;

                var result = JsonConvert.DeserializeObject<List<Item>>(resultstring);

                foreach (var ritem in result)
                {
                    if (ritem.Pagemap.Offer != null)
                    {
                        Final.Add(ritem);
                    }
                }
            }
        }

        public User sendRegisterRequest()
        {
            string resultstring;
            User newuser = new User("Ati","yells", "at", "everyone", "always", true);
            RestClient client = new RestClient("http://localhost:65505/api/Users");
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("user", newuser);

            IRestResponse response = client.Execute(request);
            resultstring = response.Content;

            var result = JsonConvert.DeserializeObject<User>(resultstring);

            return result;

        }
    }
}

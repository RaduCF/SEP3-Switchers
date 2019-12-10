using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public async Task sendRegisterRequest(string firstName,string lastName, string username, string password, string email)
        {
            User newuser = new User("Ati","yells", "at", "everyone", "always", false);
            var json = JsonConvert.SerializeObject(newuser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Users";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            if (result.Equals("Username already used."))
            {
                throw new Exception("Username already used.");
            }
        }
        public async Task sendLoginRequest(string username, string password)
        {
            List<string> info = new List<string>();
            info.Add(username);
            info.Add(password);
            var json = JsonConvert.SerializeObject(info);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            //var url = "https://localhost:44345/api/Users";
            //using var client = new HttpClient();

            //var response = await client.PostAsync(url, data);

            string result = "";//response.Content.ReadAsStringAsync().Result;
            if (result.Equals("wrong username"))
            {
                throw new Exception("invalid username");
            }
            else if (result.Equals("wrong password"))
            {
                throw new Exception("invalid password");
            }
            else { return; }
        }
    }
}

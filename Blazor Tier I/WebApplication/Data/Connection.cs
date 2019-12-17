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
                        Final.Add(ritem);
                }
            }
        }

        public async Task sendRegisterRequest(string firstName, string lastName, string username, string password, string email)
        {
            User newuser = new User(firstName, lastName, username, password, email, false);
            var json = JsonConvert.SerializeObject(newuser);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Users";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);
            Console.WriteLine("Status code is: " + response);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Username already used.");
            }
            else { }
        }

        public async Task<string> sendLoginRequest(string username, string password)
        {
            LoginInfo info = new LoginInfo { ID = username, Password = password };
            var json = JsonConvert.SerializeObject(info);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/Users/Radu";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            Console.WriteLine("Status code is: " + response);

            if (!response.IsSuccessStatusCode)
            {
                return "User name or password is incorrect.";
            }
            else
            {
                return "accepted";
            }
        }

        public async Task sendWish(UserWish wish)
        {
            //UserWish wish1 = new UserWish { Id = "ati is missing", Wish_ = new Wish() };
            var json = JsonConvert.SerializeObject(wish);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://localhost:44345/api/UserWishes";
            using var client = new HttpClient();
            Console.WriteLine("sent a wish");
            var response = await client.PostAsync(url, data);

            Console.WriteLine("Status code is: " + response.Content.ReadAsStringAsync().Result);

            //var gotwish = JsonConvert.DeserializeObject<UserWish>(response.Content.ReadAsStringAsync().Result);
        }
    }
}

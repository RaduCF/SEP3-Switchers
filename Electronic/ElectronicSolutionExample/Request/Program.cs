using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Request
{
    /*public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }*/

    class Program
    {
        static HttpClient client = new HttpClient();

        static void getItem(Item item)
            {
                Console.WriteLine($"Name: {item.Title}\tPrice: " +
                    $"{item.Price}\tRating: {item.Rating}");
            }

            static async Task<Uri> CreateItemAsync(Item item)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "api/Item", item);
                //var response = client.PostAsync("api/Item", new StringContent(
                //new JavaScriptSerializer().Serialize(cat), Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                return response.Headers.Location;
            }

            static async Task<Item> GetItemAsync(string path)
            {
                Item item = null;
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    item = await response.Content.ReadAsAsync<Item>();
                }
                return item;
            }

            static async Task<Item> UpdateCatAsync(Item item)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                    $"api/Item/{item.Id}", item);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                item = await response.Content.ReadAsAsync<Item>();
                return item;
            }

            static async Task<HttpStatusCode> DeleteItemAsync(int id)
            {
                HttpResponseMessage response = await client.DeleteAsync(
                    $"api/Item/{id}");
                return response.StatusCode;
            }

            static async Task<List<Item>> GetItemsName(string search)
            {
                client.BaseAddress = new Uri("https://localhost:44360/api/Items?name=" + search);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                List<Item> items = new List<Item>();
                var response = await client.GetAsync("https://localhost:44360/api/Items?name=" + search);
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var jsonToList = JsonConvert.DeserializeObject<List<Item>>(await response.Content.ReadAsStringAsync());
                return jsonToList;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Select a item");

                //int i = Convert.ToInt32(Console.ReadLine());

                string i = Console.ReadLine();
                Console.WriteLine(i);
                Console.WriteLine("The i selected");

                List<Item> items = new List<Item>();
                items = GetItemsName(i).Result;
            foreach (var item in items)
            {
                Console.WriteLine(item.Id);
            }

                //RunAsync(i).GetAwaiter().GetResult();
                Console.WriteLine("Here we are");
        }

        
    }
}

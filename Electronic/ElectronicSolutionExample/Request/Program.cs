using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Request
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void getItem(Item item)
            {
                Console.WriteLine($"Name: {item.Name}\tPrice: " +
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

            static void Main()
            {
                Console.WriteLine("Select an item");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(i);
                Console.WriteLine("The i selected");

                RunAsync(i).GetAwaiter().GetResult();
            }

            static async Task RunAsync(int i)
            {
                // Update port # in the following line.
                client.BaseAddress = new Uri("http://localhost:44360/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Create a new product
                    /*Item item = new Item
                    {
                        Id = 7,
                        Name = "",
                        Description = "",
                        Price = 1400,
                        Rating = 3.9
                    };

                    var url = await CreateItemAsync(item);
                    Console.WriteLine($"Created at {url}");*/
                    string url = "https://localhost:44360/api/Items/" + i.ToString();

                    // Get the product
                    Item item = await GetItemAsync(url);
                    getItem(item);

                    //url.PathAndQuery

                    // Update the product
                    //Console.WriteLine("Updating price...");
                    //item.Price = 80;
                    //await UpdateItemAsync(item);

                    // Get the updated product
                    //item = await GetItemAsync(url.PathAndQuery);
                    //getItem(item);

                    // Delete the product
                    //var statusCode = await DeleteItemAsync(item.Id);
                    //Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }
    }
}

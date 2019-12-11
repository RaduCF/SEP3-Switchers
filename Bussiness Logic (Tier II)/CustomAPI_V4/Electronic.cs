using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomAPI_V4
{

    public class Electronic
    {

        static void getItem(SomethingElectronic item)
        {
            Console.WriteLine($"Name: {item.Title}\tPrice: " +
                $"{item.Price}\tRating: {item.Rating}");
        }

        public static async Task<List<SomethingElectronic>> GetItemsName(string search)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44360/api/Items?name=" + search);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            List<SomethingElectronic> items = new List<SomethingElectronic>();
            var response = await client.GetAsync("https://localhost:44360/api/Items?name=" + search);
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var jsonToList = JsonConvert.DeserializeObject<List<SomethingElectronic>>(await response.Content.ReadAsStringAsync());
            return jsonToList;
        }
    }

}

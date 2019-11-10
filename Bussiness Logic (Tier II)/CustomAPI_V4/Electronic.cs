using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomAPI_V4
{

    class Electronic
    {
        static HttpClient client = new HttpClient();

        static async Task<SomethingElectronic> GetItemAsync(string searchItem)
        {
            string path = "https://localhost:44360/api/Items/" + searchItem;
            SomethingElectronic item = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                item = await response.Content.ReadAsAsync<SomethingElectronic>();
            }
            return item;
        }

        /*static void Main()
        {
            Console.WriteLine("Select a item");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(i);
            Console.WriteLine("The i selected");

            RunAsync(i).GetAwaiter().GetResult();
        }*/

        static async Task RunAsync(int i)
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:44360/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                
                /*string url = "https://localhost:44360/api/Items/" + i.ToString();

                // Get the product
                SomethingElectronic item = await GetItemAsync(url);
                getItem(item);*/

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        public List<SomethingElectronic> getElectronicList(string searchItem)
        {
            List<SomethingElectronic> items = new List<SomethingElectronic>();
            foreach (var item in items)
            {
                items.Add(GetItemAsync(searchItem).Result);
            }
            return items;
        }
    }
}
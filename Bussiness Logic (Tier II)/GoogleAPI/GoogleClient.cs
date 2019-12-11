
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace CustomAPI_V4
{
    public class GoogleClient
    {
        public List<Item> searchApi(string searchitem)
        {
            RestClient client = new RestClient(
                    "https://www.googleapis.com/customsearch/v1?key=KEY&cx=012558914576125397551:aqn3sajeroi&q=" + searchitem);
            RestRequest request = new RestRequest(Method.GET);

            var json = client.Execute(request).Content;

            var result = JsonConvert.DeserializeObject<Search>(json);
            List<Item> resultList = new List<Item>();

            foreach (var items in result.Items)
            {
                if (items.Pagemap.Offer != null)
                {
                    resultList.Add(items);
                }
            }
            return resultList;
        }
        //code-maze.com/different-ways-consume-restful-api-csharp/#RestSharp
        /*static void Main(string[] args)
        {
            var input = "iphone";
            RestClient client =
                new RestClient(
                    "https://www.googleapis.com/customsearch/v1?key=yourkey&cx=012558914576125397551:aqn3sajeroi&q=" + input);
            RestRequest request = new RestRequest(Method.GET);

            var json = client.Execute(request).Content;

            var result = JsonConvert.DeserializeObject<Search>(json);

            foreach (var items in result.Items)
            {
                if (items.Pagemap.Offer != null)
                {
                    Console.WriteLine("\nTitle : " + items.Title + Environment.NewLine + "Link : " + items.Link);
                    foreach (var offer in items.Pagemap.Offer)
                    {
                        Console.WriteLine($"Price of product:{offer.Price} {offer.Pricecurrency}");

                         foreach (var rating in items.Pagemap.Aggregaterating)
                         {
                             if (items.Pagemap.Aggregaterating != null)
                             {
                                 Console.WriteLine(
                                     $"Rating of product:{rating.Ratingvalue}");
                             }
                         }
                    }

                }

            }
        }
        */
    }
}



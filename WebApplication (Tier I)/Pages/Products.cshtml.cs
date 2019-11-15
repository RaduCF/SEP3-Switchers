using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Razor_pages_non_mvc.Models;
using RazorPagesMovie.Models;
using RestSharp;

namespace WebSite.Pages
{
    public class ProductsModel : PageModel
    {
        public List<Item> items = new List<Item>();
        public string resultasstring = "";
        
        public void OnGet()
        {
            var shit = "iphone";
            RestClient client = new RestClient("https://localhost:5001/api/TodoItems/");
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("title", shit);

            IRestResponse response = client.Execute(request);
            resultasstring = response.Content;

            //Search result = JsonConvert.DeserializeObject<Search>(json);
            /*List<Item> resultList = new List<Item>();
            
            foreach (var items in result.Items)
            {
                    resultList.Add(items);
            }
            items = resultList;
            */
        }
    }
}
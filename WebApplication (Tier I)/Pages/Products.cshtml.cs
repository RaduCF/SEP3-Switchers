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
        public string resultstring = "";
        [FromRoute]
        public string Search { get; set; }

        public void OnGet()
        {

            var itemname = Search;
            RestClient client = new RestClient("https://localhost:5001/api/TodoItems/");
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("title", itemname);

            IRestResponse response = client.Execute(request);
            resultstring = response.Content;

            List<Item> resultList = new List<Item>();
            var result = JsonConvert.DeserializeObject<List<Item>>(resultstring);
            
            foreach (var items in result)
            {
                resultList.Add(items);
            }
            items = resultList;
        }
    }
}
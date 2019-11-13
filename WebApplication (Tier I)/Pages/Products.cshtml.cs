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
        
        public void OnGet()
        {
            /*
            RestClient client = new RestClient("https://10.152.220.80/" + );
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
            items = resultList;
            */
        }
    }
}
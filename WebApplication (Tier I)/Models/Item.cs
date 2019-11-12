using Newtonsoft.Json;
using Razor_pages_non_mvc.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Item
    {
        [JsonProperty("title")] 
        public string Title { get; set; }

        [JsonProperty("link")] 
        public Uri Link { get; set; }

        [JsonProperty("pagemap")] 
        public Pagemap Pagemap { get; set; }
    }
}
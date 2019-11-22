using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
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
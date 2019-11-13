using Newtonsoft.Json;
using RazorPagesMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_pages_non_mvc.Models
{
    public class Search
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}

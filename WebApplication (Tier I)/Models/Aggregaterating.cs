using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_pages_non_mvc.Models
{
    public class Aggregaterating
    {
        [JsonProperty("ratingvalue")]
        public float Ratingvalue { get; set; }
    }
}

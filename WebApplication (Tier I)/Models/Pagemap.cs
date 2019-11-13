using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_pages_non_mvc.Models
{
    public class Pagemap
    {
        [JsonProperty("offer", NullValueHandling = NullValueHandling.Ignore)]
        public Offer[] Offer { get; set; }
        [JsonProperty("aggregaterating", NullValueHandling = NullValueHandling.Ignore)]
        public Aggregaterating[] Aggregaterating { get; set; }
    }
}

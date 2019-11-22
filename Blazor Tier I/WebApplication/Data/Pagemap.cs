using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Pagemap
    {
        [JsonProperty("offer", NullValueHandling = NullValueHandling.Ignore)]
        public Offer[] Offer { get; set; }
        [JsonProperty("aggregaterating", NullValueHandling = NullValueHandling.Ignore)]
        public Aggregaterating[] Aggregaterating { get; set; }
        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public Product[] Product { get; set; }

    }
}
using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public partial class Pagemap
    {

        [JsonProperty("offer", NullValueHandling = NullValueHandling.Ignore)]
        public Offer[] Offer { get; set; }

        [JsonProperty("aggregaterating", NullValueHandling = NullValueHandling.Ignore)]
        public Aggregaterating[] Aggregaterating { get; set; }

        [JsonProperty("product", NullValueHandling = NullValueHandling.Ignore)]
        public Product[] Product { get; set; }


    }

   
}
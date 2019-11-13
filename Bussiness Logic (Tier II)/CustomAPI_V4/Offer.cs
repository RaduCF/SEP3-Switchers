using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class Offer
    {
        [JsonProperty("price")] 
        public long Price { get; set; }

        [JsonProperty("pricecurrency")] 
        public string Pricecurrency { get; set; }
    }
}
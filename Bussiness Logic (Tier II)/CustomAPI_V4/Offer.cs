using Newtonsoft.Json;

namespace CustomAPI_V4
{
    public class Offer
    {

        [JsonProperty("price")] 
        public long Price { get; set; }

        [JsonProperty("pricecurrency")] 
        public string Pricecurrency { get; set; }
    }
}
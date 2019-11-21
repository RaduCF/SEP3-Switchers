using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class Offer :IComparable
    {
        [JsonProperty("price")] 
        public long Price { get; set; }

        [JsonProperty("pricecurrency")] 
        public string Pricecurrency { get; set; }

        public int CompareTo(object obj)
        {
            return Price.CompareTo(obj);
        }
    }
}
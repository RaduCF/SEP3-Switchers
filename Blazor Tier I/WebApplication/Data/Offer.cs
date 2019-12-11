using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class Offer
    {
        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("pricecurrency")]
        public string Pricecurrency { get; set; }
    }
}
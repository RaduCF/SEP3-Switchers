using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication.Data
{
    public class Product
    {
        [JsonProperty("photo")]
        public Uri Photo { get; set; }
    }
}

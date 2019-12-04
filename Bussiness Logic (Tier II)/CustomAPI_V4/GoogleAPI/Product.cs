using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    public class Product
    {
        [JsonProperty("photo")]
        public Uri Photo { get; set; }
    }
}

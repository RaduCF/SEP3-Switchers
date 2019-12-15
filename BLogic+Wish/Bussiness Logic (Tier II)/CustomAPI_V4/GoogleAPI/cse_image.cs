using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAPI_V4.GoogleAPI
{
    public class Cse_image
    {
        [JsonProperty("src")]
        public string src { get; set; }

    }
}

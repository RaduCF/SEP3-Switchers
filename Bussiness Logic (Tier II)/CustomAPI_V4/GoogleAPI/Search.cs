using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class Search
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }

        [JsonProperty("queries")]
        public Queries Queries { get; set; }

    }


    
  


    
}
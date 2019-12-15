using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class Item
    {

        [JsonProperty("title")] 
        public string Title { get; set; }

        [JsonProperty("link")] 
        public Uri Link { get; set; }

        [JsonProperty("pagemap")] 
        public Pagemap Pagemap { get; set; }
    }
}
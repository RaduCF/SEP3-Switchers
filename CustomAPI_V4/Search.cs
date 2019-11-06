using Newtonsoft.Json;

namespace CustomAPI_V4
{
    public class Search
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }


    
  


    
}
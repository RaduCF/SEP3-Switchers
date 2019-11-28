using Newtonsoft.Json;

namespace CustomAPI_V4
{
    public class NextPage
    {
        [JsonProperty("searchTerms")]
        public string SearchTerms { get; set; }
    }
}
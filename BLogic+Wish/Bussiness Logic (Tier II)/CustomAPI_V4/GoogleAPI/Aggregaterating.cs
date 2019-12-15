using Newtonsoft.Json;

namespace CustomAPI_V4
{
    /*https://app.quicktype.io/#l=cs&r=json2csharp */
    public class Aggregaterating
    {
        [JsonProperty("ratingvalue")]
        public float Ratingvalue { get; set; }
    }

}

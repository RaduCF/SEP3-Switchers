using System;
using Newtonsoft.Json;

namespace CustomAPI_V4
{
    [Serializable]
    public class FinalItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public string PriceCurrency { get; set; }
        public double Rating { get; set; }
    }
}
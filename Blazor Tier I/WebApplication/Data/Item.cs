using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Data
{
    public class Item
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public string PriceCurrency { get; set; }
        public double Rating { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Request
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The name of the item cannot be longer than 60 characters")]
        [Required]
        public string Title { get; set; }
        public string URL { get; set; }
        public string ImageURL { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        public string PriceCurrency { get; set; }
        public double Rating { get; set; }
    }
}

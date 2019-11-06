using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic.Data.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "The name of the item cannot be longer than 60 characters")]
        [Required]
        public string Name { get; set; }
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        public double Rating { get; set; }
    }
}

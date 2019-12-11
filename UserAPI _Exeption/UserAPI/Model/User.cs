using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Model
{
    public class User
    {
       // [Required]
        public string FirstName { get; set; }
      //  [Required]
        public string LastName { get; set; }
       // [Required]
        public string ID { get; set; } // the only primary key accepted is ID therefor the username is changed to ID
      //  [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
      //  [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        
    }
}

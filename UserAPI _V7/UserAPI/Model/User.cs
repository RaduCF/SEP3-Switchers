using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Model
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; } // the only primary key accepted is ID therefor the username is changed to ID
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        
    }
}

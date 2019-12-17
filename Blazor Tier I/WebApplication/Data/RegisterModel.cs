using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "User name has to be between 6 and 20 characters.")]
        public string ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password has to be between 6 and 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}

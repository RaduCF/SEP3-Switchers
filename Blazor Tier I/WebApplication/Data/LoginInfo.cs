using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class LoginInfo
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "User name has to be between 6 and 20 characters.")]
        [DataType(DataType.Text)]
        public string ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password has to be between 6 and 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

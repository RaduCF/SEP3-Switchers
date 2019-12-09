using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Data
{
    public class User
    {
        public User(string firstName, string lastName, string iD, string password, string email, bool isAdmin)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            ID = iD ?? throw new ArgumentNullException(nameof(iD));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            IsAdmin = isAdmin;
        }

        public User() { }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; } // the only primary key accepted is ID therefor the username is changed to ID
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }


    }
}
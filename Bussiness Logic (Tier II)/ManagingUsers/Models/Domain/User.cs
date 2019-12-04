using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingUsers.Models.Domain
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public WishList wish { get; set; }

        public User(string Firstname, string Lasttname, string Username, string Password, string Email, bool IsAdmin, WishList wish)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.IsAdmin = false;
            this.wish = new WishList();
        }

        public string getUsername()
        {
            return Username;
        }

        public string ToString()
        {
            return $"Firstname: {Firstname}\n" +
                   $"Lastname: {Lastname}\n" +
                   $"Username: {Username}\n" +
                   $"Password: {Password}\n" +
                   $"Email: {Email}\n" +
                   $"IsAdmin: {IsAdmin}\n" +
                   $"wishList: {wish}";
        }

        public String GetFirstname()
        {
            return Firstname;
        }

        public String GetLastname()
        {
            return Lastname;
        }

        public String GetUsername()
        {
            return Username;
        }

        public String GetPassword()
        {
            return Password;
        }

        public String GetEmail()
        {
            return Email;
        }

        public bool GetIsAdmin()
        {
            return IsAdmin;
        }

    }
}

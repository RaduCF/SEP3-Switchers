using System;
using System.Collections.Generic;

namespace CompareIT_API.Model
{
    public class User
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
       // public  WishList wish { get; set; }

        public User(string Firstname, string Lasttname, string Username, string Password, string Email, bool IsAdmin/*, WishList wish*/)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Username = Username;
            this.Password = Password;
            this.Email = Email;
            this.IsAdmin = false;
           // this.wish= new WishList();
            
        }

       

       /* public string ToString()
        {
            return $"Firstname: {Firstname}\n" +
                   $"Lastname: {Lastname}\n" +
                   $"Username: {Username}\n" +
                   $"Password: {Password}\n" +
                   $"Email: {Email}\n" +
                   $"IsAdmin: {IsAdmin}\n" 
                   $"wishList: {wish}";
        }*/

       /* public void RegisterWish(string URL)
        {
            wish.registerWish(URL);
        }*/

      


    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace CompareIT_API
{
    public class ModelManager : IComareModel
    {
        public UserList userList { get; set; }
        public WishList wishList { get; set; }
        public User user1 { get; set; }

        public ClientCSharp clientC { get; set; } //from java

       /* public UserList loadUsers()
        {
            return Database.loadUsers();
        }
        public WishList loadWishes(String username)
        {
            return Database.loadWishes(username);
        }

        public User OneUser(string username)
        {
           // return Database.OneUser(username);
            
        }

        public bool registerWish(string URL, User username)
        {
           // Database.registerWish(URL, username);
            return true;
        }

        public bool removeWish(Wish wish)
        {
           // Database.removeWish(wish);
            return true;

        }*/

        public bool registerUser(User user)
        {
            user =new User ("Radu", "is", "late", "again", "hh@Se.com", false);
            clientC.RegisterUser(user);
            return true;
        }

       /* public bool removeUser(User user)
        {
            Database.removeUser(user);
            return true;

        }

        public bool LoginUser(User user)
        {
            Database.loadUsers(user);
            foreach (var client in userList.userList)
            {
                if
                (
                    (user.Equals(client.Username))
                    ||
                    (user.Password.Equals(client.Password))
                )
                {
                    return true;
                }
            }
            return false;
        }*/
    }


}


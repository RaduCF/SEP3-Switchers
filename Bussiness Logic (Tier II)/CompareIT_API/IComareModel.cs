using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;


namespace CompareIT_API
{
    interface IComareModel
    {
        /*UserList loadUsers();
        WishList loadWishes(String username);
        User OneUser(String username);
        bool registerWish(String URL, User username);
        bool removeWish(Wish wish);
       
        bool removeUser(User user);*/
 bool registerUser(User user);
    }
}


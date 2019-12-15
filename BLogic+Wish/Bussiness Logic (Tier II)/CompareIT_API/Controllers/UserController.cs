/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Microsoft.AspNetCore.Mvc;

namespace CompareIT_API.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly ModelManager manager;

        public UserController(ModelManager manage)
        {
            this.manager = manager;
        }

        // POST: api/AddUser
        [HttpPost]
        public bool CreateUser(User user)
        {
            return manager.registerUser(user);
             
        }

       /* // POST: api/AddWish
        [HttpPost]
        public bool CreateWish(string URL, User username)
        {
            return manager.registerWish(URL, username);
        }


        // PUT: api/DeleteUser
        [HttpPut]
        public bool DeleteUser(User user)
        {
            return manager.removeUser(user);
             
        }

        // PUT: api/DeleteWish
        [HttpPut]
        public bool DeleteWish(Wish wish)
        {
            return manager.removeWish(wish);

        }

        // GET: api/AllUser
        [HttpGet]
        public UserList ShowAllUsers()
        {
         return manager.loadUsers();
          
        }

        // GET: api/Wishes
        [HttpGet]
        public WishList loadWishesForOneUser(String username)
        {
           return manager.loadWishes(username);
        }


        // GET: api/SpecificUser
        [HttpGet]
        public User SpecificUser(string Username, User user)
        {
            return  manager.OneUser(Username);           
            
        }

        // POST: api/Login
        [HttpPost]
        public User Login(User user)
        {
            manager.logIn(user);
            var result=  manager.userList.getUserTostring(user);
            return result;
        }
        

    }
}*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompareIT_API.Model;

namespace CompareIT_API.Model
{
    public class ModelManager
    {
        public UserList userList { get; set; }
        public WishList wishList { get; set; }

        public void ListOfAllUsers()
        {
         userList.loadUsers();   
        }

        public void ListofAllWishes(String username)
        {

        }

        public void registerNewUser(string Firstname, string Lasttname, string Username, string Password, string Email, bool IsAdmin, WishList wish)
        {
            User user= new User(Firstname, Lasttname, Username,Password, Email,IsAdmin,wish );
        }

        public void removeUser(User user)
        {
            userList.removeUser(user);
        }

        public void AddWish(string URL, Wish wish)
        {
            wishList.registerWish(URL);
            
        }

        public void DeleteWish(Wish wish)
        {
            wishList.removeWish(wish);
        }

        public void logIn(User user)
        {
            userList.LoginUser(user);
        }

        //--------------------------------------------------------------------------------------------

/*
        public void logOff() 
        {
        user.logOff(this.user);

        }

*/

}
}

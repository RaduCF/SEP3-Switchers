using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingUsers.Models.Domain
{
    public class UserList: ModelManager
    {
        public List<User> userList { get; set; }


        // shows the whole list with their properties. 
        public void loadUsers()
        {
            foreach (var user in userList)
            {
                user.ToString();
            }
        }

        public void loadOneUser(String username)
        {
            foreach (var user in userList)
            {
                if (username.Equals(user.getUsername()))
                {
                    username.ToString();
                }
            }

        }

        public void registerUser(string Firstname, string Lasttname, string Username, string Password, string Email, bool IsAdmin, WishList wish)
        {
            User user = new User(Firstname, Lasttname, Username, Password, Email, IsAdmin, wish);
            userList.Add(user);
        }

        public void removeUser(User user)
        {
            foreach (var users in userList)
            {
                if (user.Equals(users))
                {
                    userList.Remove(user);
                }

            }

        }

        public void loadWishes(String username)
        {
            foreach (var user in userList)
            {
                if (username.Equals(user.getUsername()))
                {
                    user.wish.wishList.ToString();
                }
            }
        }

        public bool LoginUser(User user)
        {
            foreach (var client in userList)
            {
                if
                (
                    (user.GetUsername().Equals(client.GetUsername()))
                    ||
                    (user.GetPassword().Equals(client.GetPassword()))
                )
                {
                    return true;
                }
            }
            return false;
        }
    }
}

    


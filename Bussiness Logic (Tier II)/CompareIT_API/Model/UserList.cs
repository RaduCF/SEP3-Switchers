using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompareIT_API.Model
{
    public class UserList
    {
        public List<User> userList { get; set; }


        // shows the whole list with their properties. 
        /*  public void loadUsers() 
          {
              foreach (var user in userList)
              {
                  user.ToString();
              }
          }*/

        /* public void loadOneUser(String username)
         {
             foreach (var user in userList)
             {
                 if (username.Equals(user.getUsername()))
                 {
                     username.ToString();
                 }
             }
 
         }*/

        public void AddUser(User user)
        {
            userList.Add(user);
        }

        public void removeUser(User user)
        {
            if (userList.Contains(user))
            {
                userList.Remove(user);
            }
        }

        /*  public void loadWishes(String username)
          {
              foreach (var user in userList)
              {
                  if (username.Equals(user.getUsername()))
                  {
                      user.wish.wishList.ToString();
                  }
              }
          }*/



        /*    public User getUserTostring(User user)
            {
                user.ToString();
            }
        }*/
    }
}

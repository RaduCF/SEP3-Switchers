using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UserAPI.Model;

namespace UserAPI
{
    public class UserLogic
    {
        private Client_CSharp client;
        private bool loggedIn;
        public UserLogic()
        {
            this.client = new Client_CSharp();
            this.loggedIn = false;
        }

        //validate the registration
       /* public void Validate(User user) // not sure about the parameter user
        {
            Send(user);

            if (client.ReceiveMessage())// Recivemessage contain is a boolean if the ID already exist in database
            {
                throw new System.ArgumentException("User already exist");
            }
            else if (user.Password == null || user.Password.Length < 6)
            {
                throw new System.ArgumentException("Password must contain at least 6 characters");
            }
            else if (user.FirstName == null || user.LastName == null || user.Email == null || user.IsAdmin == null)
            {
                throw new System.ArgumentException("Please fill out the form before submitting");
            }
        }*/
        /*public void Send<T>(T value, T value2) // a generic method to send info to tier 3 through Client_Csharp
        {
            client.Send(value);
        }*/


        public void RegisterUser(User user)
        {
           // if (Validate(user))

              client.RegisterUser(user);
           // client.ReceiveMessage(); // to receive a confirmation for registeration
        }


        //----------------------------Login------------------------------------//

        /* public bool isLoggedIn()
         {
             return loggedIn;
         }*/

        public void Login(string ID, string Password)
        {
            client.Send(ID, Password); // sending to be checked in tier 3
          /*  if (client.ReceiveMessage()) //if both ID and Password are true
            {
                loggedIn = true;
            }
            else
            {
                throw new System.ArgumentException("Password is not correct");
            }*/
        }

    }
}
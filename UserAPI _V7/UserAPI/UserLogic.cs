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

        public void RegisterUser(User user)
        {
            client.SendUser(user);
         
        }

        //----------------------------Login------------------------------------//

        /* public bool isLoggedIn()
         {
             return loggedIn;
         }*/

        public void Login(Login login)
        {
        client.SendLogin(login); // sending to be checked in tier 3
            if (client.ReciveVerification().Equals(true) )//if login message is true
            {
                loggedIn = true;
            }
            else
            {
                throw new System.ArgumentException("Password is not correct");
            }
        }

    }}

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
        //check if we can send user or should be string
       /* public bool Validate(User user) // not sure about the parameter user
        {
            //  client.SendID(ID);
            client.RegisterUser(user);

            if (client.ReciveVerification().Equals(true))// Recivemessage contains a boolean if the ID already exist in database
            {Console.WriteLine("User already exist");
                throw new System.ArgumentException("User already exist");
                

            }
            else if (user.Password == null ||user.Password.Length < 6)
            {
                Console.WriteLine("incorrect Password");
                throw new System.ArgumentException("Password must contain at least 6 characters");
            }
            else if (user.FirstName == null || user.LastName == null || user.Email == null)
            {
                throw new System.ArgumentException("Please fill out the form before submitting");
            }
            else
            { return true;
            }
        }*/


        /*public void SendID(string ID) // a method to send the ID to check if the ID already exist 
        {
            client.Send(ID);
        }*/


        public void RegisterUser(User user)
        {
            //if (Validate(user).Equals(true))
            //{
                client.RegisterUser(user);
           //}

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

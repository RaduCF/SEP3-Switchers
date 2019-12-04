
using System;
using UserAPI.Model;

namespace UserAPI.Mediator
{
    public class ModelManager
    {
        private Client_CSharp client = new Client_CSharp();

        public void RegisterUser(User user)
        {
            client.RegisterUser(user);
            Console.WriteLine(user);
           client. ReceiveMessage();
        }

       
    }
}

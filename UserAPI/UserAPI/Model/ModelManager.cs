using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Model;

namespace UserAPI
{
    public class ModelManager
    {
        /*private Client_CSharp client;
        private byte[] data = new byte[1024];
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public void RegisterUser(User user)
        {
            socket.Connect("10.152.208.122", 6789);
            string json = System.Text.Json.JsonSerializer.Serialize(user);
            data = Encoding.Default.GetBytes(json);
            socket.Send(data);
            socket.Close();
        }
        */
        public void RegisterUser(User user)
        {
            
            //client.RegisterUser(user);
        }

    }
}

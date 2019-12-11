using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CompareIT_API.Model;
using Newtonsoft.Json;

namespace CompareIT_API
{
    public class ClientCSharp
    {
       // private TcpClient client = new TcpClient("10.152.208.35", 6789);
        private byte[] data= new byte[1024];
        private  Socket socket= new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
       // private NetworkStream stream;

        public void RegisterUser(User user)
        {
            //stream = client.GetStream();
            socket.Connect("10.152.208.35", 6789);
           // string jsonString = JsonConvert.SerializeObject(user);
            //data = Encoding.ASCII.GetBytes(jsonString);
           // stream.Write(data,0,data.Length);
           string json = System.Text.Json.JsonSerializer.Serialize(user);
           data = Encoding.Default.GetBytes(json);
           socket.Send(data);
          //  Console.WriteLine("sent");
            socket.Close();
            //client.Close();



        }
    }
}

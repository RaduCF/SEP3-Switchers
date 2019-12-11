using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UserAPI.Mediator;
using UserAPI.Model;

namespace UserAPI
{
    public class Client_CSharp
    {
        private byte[] data = new byte[1024];
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

          

        public void RegisterUser(User user)
        {
           System.Console.WriteLine("hi");
            //UModel username = new UModel("hgdohg", "hgohrog", "rhogoregh", "grgjr", "rheroi@gmail.com", true);
            socket.Connect("10.152.208.109", 6789);
            string json = System.Text.Json.JsonSerializer.Serialize(user);
            data = Encoding.Default.GetBytes(json);
            socket.Send(data);
            socket.Close();

        }

        public void UserExists(User user)
        {
            //something here
        }


        public string ReceiveMessage()
        {          
            IPAddress ip = IPAddress.Parse("10.152.208.109");
             TcpListener listener = new TcpListener(ip, 6799);
           
            listener.Start();
            Console.WriteLine("server started");
             while (true) 
            {
             TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("accepted");
            NetworkStream stream = client.GetStream();
            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);
            string s = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            Console.WriteLine(s);
            client.Close();
            Console.WriteLine("closed");
        }
        }
    }
}
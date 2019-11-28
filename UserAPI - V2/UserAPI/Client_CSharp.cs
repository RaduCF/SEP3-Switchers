using System.Net.Sockets;
using System.Text;
using UserAPI.Model;

namespace UserAPI
{
    public class Client_CSharp
    {
        private byte[] data = new byte[1024];
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        public void RegisterUser(User user)
        {
            socket.Connect("10.152.208.35", 6789);
            string json = System.Text.Json.JsonSerializer.Serialize(user);
            data = Encoding.Default.GetBytes(json);
            socket.Send(data);
            socket.Close();

        }
    }
}
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UserAPI.Model;

namespace UserAPI
{
    public class Client_CSharp
    {
        private byte[] data = new byte[1024];
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private string json;
        private byte[] toSendBytes;
        private byte[] toSendLenBytes;
        private int toSendLen;
        private IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.1.3"), 6789);

        public Client_CSharp()
        {
            clientSocket.Connect(serverAddress);
        }
         public void Send(string ID, string Password) // sending to tier 3
          {   //this should send two strings in an array and be received by tier3 and convert it to 
            //login object with having only username and password the controller need some word
            //in order to send both parameters , right now in java I can get only the username and the password is null
            //and it does not convet it to login object

            var loginInof = new string[2];
            loginInof[0] = ID;
            loginInof[1] = Password;

            json = System.Text.Json.JsonSerializer.Serialize(loginInof);
          
             toSendLen = System.Text.Encoding.ASCII.GetByteCount(json);
           toSendBytes = System.Text.Encoding.ASCII.GetBytes(json);
             toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);
                      
            ReceiveMessage();
        }

        public void RegisterUser(User user)
        {


             json = System.Text.Json.JsonSerializer.Serialize(user);
            toSendLen = System.Text.Encoding.ASCII.GetByteCount(json);
            toSendBytes = System.Text.Encoding.ASCII.GetBytes(json);
            toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);
            ReceiveMessage();
        }
        public void ReceiveMessage() { 
           
            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);

           // clientSocket.Close();
                }
        

        /* public void UserExists(User user)
         {
             //something here
         }*/


        
    }
}
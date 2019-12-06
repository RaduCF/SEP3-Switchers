﻿using System;
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
         public void Send(Login login) 
          {  
           json = System.Text.Json.JsonSerializer.Serialize(login);
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
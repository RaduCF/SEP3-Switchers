using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace CustomAPI_V4
{
    class MainClient
    {
        

        public static void Main(string[] args)
        {
            var gClient = new GoogleClient();
            var electronic = new Electronic();

            executeServer();

            /*
            foreach (var Item in gClient.searchApi("iphone"))
            {
                Console.WriteLine($"Title= {Item.Title}\nLink={Item.Link}");
                foreach (var i in Item.Pagemap.Offer)
                {
                    Console.WriteLine($"Price= {Item.Pagemap.Offer[0].Price} {Item.Pagemap.Offer[1].Pricecurrency}");
                }
            }
            foreach (var Item in electronic.getElectronicList("iphone"))
            {
                Console.WriteLine(Item);
            }
            */
        }
        public static void executeServer()
        {
            try {
                byte[] adr = { 192, 168, 1, 81 };
                IPAddress ipadr = new IPAddress(adr);
                TcpListener listen = new TcpListener(ipadr, 5000);
                listen.Start();
                Console.WriteLine("server started.");

                TcpClient client = listen.AcceptTcpClient();
                Console.WriteLine("Client acceepted.");

                
                var received = "";
                int numByte = 0;
                NetworkStream stream = client.GetStream();
                byte[] bytestring;
                Console.WriteLine("Message received: " + received);
            }
            catch( Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }
    }
}

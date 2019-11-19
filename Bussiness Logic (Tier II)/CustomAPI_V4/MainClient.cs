using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace CustomAPI_V4
{
    class MainClient
    {
        

        public static void Main(string[] args)
        {
            executeServer();

            var gClient = new GoogleClient();
            var electronic = new Electronic();
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
            
        }
        public static void executeServer()
        {
            try {
                var gClient = new GoogleClient();
                var electronic = new Electronic();

                byte[] adr = { 10,152,208,38 };
                IPAddress ipadr = new IPAddress(adr);
                TcpListener listen = new TcpListener(ipadr, 5000);
                listen.Start();
                Console.WriteLine("Server started.");
                while (true) {
                    Console.WriteLine("Waiting for connection...");
                    TcpClient client = listen.AcceptTcpClient();
                    Console.WriteLine("Connection accepted.");

                    NetworkStream stream = client.GetStream();

                    byte[] bytes= new byte[1024];
                    
                    int bytesRead = stream.Read(bytes,0,bytes.Length);
                    var search = Encoding.ASCII.GetString(bytes, 0, bytesRead);
                    Console.WriteLine("Message received: " + search);

                    var items = gClient.searchApi(search);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, items);
                }
            }
            catch ( Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
        }
    }
}

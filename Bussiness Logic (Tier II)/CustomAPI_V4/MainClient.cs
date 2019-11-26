using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAPI_V4
{
    class MainClient
    {
        public static void Main(string[] args)
        {
<<<<<<< HEAD
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
=======
            Console.WriteLine("client started...");
>>>>>>> Pouneh



        }
    }
}

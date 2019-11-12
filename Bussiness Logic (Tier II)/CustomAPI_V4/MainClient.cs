using System;
using System.Collections.Generic;
using System.Text;

namespace CustomAPI_V4
{
    class MainClient
    {
        

        public static void Main(string[] args)
        {
            var gClient = new GoogleClient();
            var electronic = new Electronic();
<<<<<<< Updated upstream

||||||| merged common ancestors

            executeServer();

            /*
=======
            var compareit = new CompareIT();
            executeServer();
            
            //compareit.LowPrice("iphone");

            /*
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
||||||| merged common ancestors
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
            
=======
            */
        }
        public static void executeServer()
        {
            try {
                byte[] adr = { 192,168,1,4 };
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
            
>>>>>>> Stashed changes
        }
    }
}

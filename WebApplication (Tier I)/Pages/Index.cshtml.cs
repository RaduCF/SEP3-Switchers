using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Razor_pages_non_mvc.Pages
{
    public class IndexModel : PageModel
    { 
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //if (!string.IsNullOrEmpty(SearchString)) {
            
                
            //}
        }
        public void OnPost()
        {
            try
            {
                byte[] adr = { 192, 168, 1, 81 };
                TcpClient client = new TcpClient("192.168.1.81", 5000);
                client.Connect(new IPEndPoint(new IPAddress(adr), 5000));
                Console.WriteLine("connected to server.");
                NetworkStream stream = client.GetStream();
                byte[] bytestring = Encoding.ASCII.GetBytes(SearchString);
                stream.Write(bytestring, 0, SearchString.Length);
                Console.WriteLine("sent string to server: " + SearchString);
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
}

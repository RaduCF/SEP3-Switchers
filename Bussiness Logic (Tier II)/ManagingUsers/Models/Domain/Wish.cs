using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingUsers.Models.Domain
{
    public class Wish
    {
        public string Title { get; set; }
        public string URL_ { get; set; }
        
        public Wish(string Title, string URL_)
        {
            this.Title = Title;
            this.URL_ = URL_;
        }
    }
}
}

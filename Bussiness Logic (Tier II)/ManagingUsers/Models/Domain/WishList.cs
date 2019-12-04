using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagingUsers.Models.Domain
{
    public class WishList
    {
        public List<Wish> wishList { get; set; }

        public WishList()
        {
            this.wishList = new List<Wish>();
        }


        public void registerWish(string Title, string URL_)
        {
            Wish wish = new Wish(Title, URL_);
            wishList.Add(wish);
        }

        public void removeWish(Wish wish)
        {
            foreach (var wishes in wishList)
            {
                if (wish.Equals(wishes))
                {
                    wishList.Remove(wish);
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;

namespace CompareIT_API.Model
{
    public class WishList
    {
        public List<Wish> wishList { get; set; }

        public WishList()
        {
            this.wishList= new List<Wish>();
        }


        public void registerWish(string URL)
        {
                Wish wish = new Wish(URL);
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
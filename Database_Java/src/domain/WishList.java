package domain;

import java.util.ArrayList;

public class WishList {
    private ArrayList<Wish> wishList;

    public WishList() {
        this.wishList = new ArrayList<Wish>();
    }

    public void addWish(String url) {

        Wish wish = new Wish(url);
        wishList.add(wish);
    }

    public void removeWish(Wish wish) {


        if (wishList.contains(wish)) {
            wishList.remove(wish);
        }
    }
}

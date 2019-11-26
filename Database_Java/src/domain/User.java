package domain;

import java.io.Serializable;

public class User implements Serializable {
    private String FirstName;
    private String LastName;
    private String Username;
    private String Password;
    private String Email;
    private boolean IsAdmin;
    // private WishList wish;


    public User(String firstName, String lastName, String username, String password, String email, boolean isAdmin) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.IsAdmin = false;
        // this.wish = new WishList();
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        this.FirstName = firstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        this.LastName = lastName;
    }

    public String getUsername() {
        return Username;
    }

    public void setUsername(String username) {
        this.Username = username;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        this.Password = password;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        this.Email = email;
    }

    public boolean isAdmin() {
        return IsAdmin;
    }

    public void setAdmin(boolean admin) {
        IsAdmin = admin;
    }

   /* public WishList getWish() {
        return wish;
    }

    public void setWish(WishList wish) {
        this.wish = wish;
    }*/

//   public void addWish(String URL){
//       wish.addWish(URL);
//   }


    @Override
    public String toString() {
        return "User{" +
                "firstName='" + FirstName + '\'' +
                ", lastName='" + LastName + '\'' +
                ", username='" + Username + '\'' +
                ", password='" + Password + '\'' +
                ", email='" + Email + '\'' +
                ", isAdmin=" + IsAdmin +
                '}';
    }
}

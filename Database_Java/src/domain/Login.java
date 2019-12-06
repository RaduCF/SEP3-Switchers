package domain;

import com.sun.source.doctree.SerialDataTree;

import java.io.Serializable;

public class Login implements Serializable {
    private String ID;
    private  String Password;

    public Login(String username,String password){
        this.ID=username;
        this.Password=password;
    }

    public String getPassword() {
        return Password;
    }

    @Override
    public String toString() {
        return "Login{" +
                "ID='" + ID + '\'' +
                ", password='" + Password + '\'' +
                '}';
    }

    public String getID() {
        return ID;
    }
}

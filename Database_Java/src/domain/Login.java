package domain;

public class Login {
    private String ID;
    private  String password;

    public Login(String username,String password){
        this.ID=username;
        this.password=password;
    }

    public String getPassword() {
        return password;
    }

    @Override
    public String toString() {
        return "Login{" +
                "ID='" + ID + '\'' +
                ", password='" + password + '\'' +
                '}';
    }

    public String getID() {
        return ID;
    }
}

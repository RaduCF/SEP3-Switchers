package DataPersistence;

import domain.User;
import org.junit.Before;
import org.junit.Test;

import java.sql.SQLException;


public class Compare_DatabaseTest {
    private Compare_Database db;
    private User user;

    @Before
    public void setUp() throws Exception {
        this.db= new Compare_Database();
    }

    @Test
    public void loadOneUser() throws SQLException {
        String username="gav";
        System.out.println(db.loadOneUser(username));

    }

    @Test
    public void registerUser() throws SQLException {
        user= new User("loli","nimo","kalagh","worm","no@ddl.com",false);
        db.registerUser(user);
    }

    @Test
    public void removeUser() throws SQLException {
        user= new User("loli","nimo","kalagh","worm","no@ddl.com",false);

        db.removeUser(user);
    }

    @Test
    public void userExists() throws SQLException {
        user= new User("loli","nimo","kalagh","worm","no@ddl.com",false);
        System.out.println(db.userExists(user.getID()));
    }

    @Test
    public void validateLogin() throws SQLException {
        String u="adam";
        String p="jojrgvc";
        System.out.println(db.validateLogin(u,p));

    }
}
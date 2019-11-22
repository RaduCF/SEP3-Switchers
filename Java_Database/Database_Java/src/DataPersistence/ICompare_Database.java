package DataPersistence;
import java.sql.SQLException;
import java.util.ArrayList;


public interface ICompare_Database
    {
        UserList loadUsers() throws SQLException;
        WishList loadWishes(String username) throws SQLException;
        Users loadOneUser(String username)throws SQLException;
        void registerWish(Wish wish) throws SQLException;
        void removeWish(Wish wish) throws SQLException;
        void registerUser(Users user) throws SQLException;
        void removeUser(Users user) throws SQLException;


    }




package DataPersistence;
import domain.User;
import domain.UserList;
import domain.Wish;
import domain.WishList;

import java.sql.SQLException;
import java.util.ArrayList;


public interface ICompare_Database
    {
       /* UserList loadUsers() throws SQLException;
        WishList loadWishes(String username) throws SQLException;
        User loadOneUser(String username)throws SQLException;
        void registerWish(Wish wish) throws SQLException;
        void removeWish(Wish wish) throws SQLException;*/
        void registerUser(User user) throws SQLException;
        void removeUser(User user) throws SQLException;


    }




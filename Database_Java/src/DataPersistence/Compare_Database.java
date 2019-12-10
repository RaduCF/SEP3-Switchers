package DataPersistence;

import domain.User;
import utility.persistence.MyDatabase;

import java.sql.SQLException;
import java.util.ArrayList;

public class Compare_Database implements ICompare_Database {


    private MyDatabase db;

    //    Fill out with your postgres password
    private static final String DRIVER = "org.postgresql.Driver";
    private static final String URL = "jdbc:postgresql://localhost:5432/postgres";
    private static final String USER = "postgres";
    private static final String PASSWORD = "1193";


    public Compare_Database() {
        try {
            this.db = new MyDatabase(DRIVER, URL, USER, PASSWORD);
            System.out.println("connect to database");

        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }


    //The method simply creates a list of users from the database in order to be used in the model.

       /* public UserList loadUsers() throws SQLException
        {
            String person = "SELECT Users.username, Users.password,Users.firstname,Users.lastname,Users.email,Users.isAdmin,Wish.url " +
                    "FROM public.Users " +
                    "inner join Wish.url on Users.username = Wish.username;";
            UserList list = new UserList();
            ArrayList<Object[]> UsersList = db.query(person);
            for (int i = 0; i < UsersList.size(); i++)
            {
                Object[] array = UsersList.get(i);
                User user = new User(String.valueOf(array[0]), String.valueOf(array[1]),
                        String.valueOf(array[2]), String.valueOf(array[3]), String.valueOf(array[4])
                        , String.valueOf(array[5]), String.valueOf(array[6]));
                list.registerUser(user);
            }
            return list;
        }

        //The method passes a String type username as a parameter and returns a wishList for a specific user.
        public WishList loadWishes(String username) throws SQLException
        {
            String sqlWish = "SELECT Wish.url,username where username = ?;";
            WishList list = new WishList();
            ArrayList<Object[]> wishes = db.query(sqlWish, username);
            for (int i = 0; i < wishes.size(); i++)
            {
                Object[] array = wishes.get(i);
                Wish wish = new Wish(array[0] + "", loadOneUser(array[1] + ""));
                list.registerWish(wish);
            }
            return list;
        }


        //This method registers a new wish
        public synchronized void registerWish(Wish wish) throws SQLException
        {
            String newWish = "INSERT INTO public.Wish(url,username)" +
                    "VALUES( ?,?);";
            db.update(newWish, wish.getID(), wish.getUrl());
        }

        //This method removes a wish
        public synchronized void removeWish(Wish wish) throws SQLException
        {
            String count = "SELECT COUNT(*) AS myRow FROM public.Wish WHERE Wish.username=?;";
            String sql = "DELETE FROM public.Wish where username=?;";
            int myCount = 0;

            ArrayList<Object[]> rows = db.query(count, wish.getID());
            myCount = Integer.parseInt(rows.get(0)[0].toString());
            if (myCount > 1)
            {
                db.update(sql, wish.getUrl(), wish.getID());
            } else {

            }
        }*/
    //This is a private method which loads only one user by passing a username as an argument and return one user.

    public synchronized User loadOneUser(String username) throws SQLException {
        String sql = "SELECT Users.username, Users.password,Users.firstname,Users.lastname,Users.email,Users.isAdmin " +
                "FROM Public.Users WHERE username=?; ";

        User user = null;

        ArrayList<Object[]> user1 = db.query(sql, username);
        for (int i = 0; i < user1.size(); i++) {
            Object[] array = user1.get(i);
            user = new User(array[0] + "", array[1] + "", array[2] + "", array[3] + "", array[4] + "", (boolean) array[5]);
        }
        return user;
    }

    //This method adds a user
    public synchronized void registerUser(User user) throws SQLException {

        String person = "INSERT INTO Public.Users(username,password,firstname,lastname,email,isAdmin) VALUES (?,?,?,?,?,?);";
        db.update(person, user.getID(), user.getPassword(), user.getFirstName(), user.getLastName(), user.getEmail(), user.isAdmin());

        System.out.println("this is done");
    }


    //This method deletes a specific user
    public synchronized void removeUser(User user) throws SQLException {
        String sql = "DELETE FROM Public.Users WHERE username=?;";
        db.update(sql, user.getID());
    }

    @Override
    public synchronized boolean userExists(String username) throws SQLException {
        String sql = "SELECT username FROM Public.Users  WHERE username=?;";

        ArrayList<Object[]> id = db.query(sql, username);
        if (id != null) {
            return true;
        } else {
            return false;
        }

    }

    @Override
    public synchronized boolean validateLogin(String username, String password) throws SQLException {
        String sql = "SELECT username, password FROM Public.Users WHERE username=? ;";
        ArrayList<Object[]> user = db.query(sql, username);

        for (int i = 0; i < user.size(); i++) {
            Object[] array = user.get(i);
            String us = array[0] + "";
            String ps = array[1] + "";


            if (us.equals(username)) {
                if (ps.equals(password)) {
                    return true;
                }
            }
        }

        return false;



    }
}






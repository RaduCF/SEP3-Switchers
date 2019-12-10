package DataPersistence;
import utility.persistence.MyDatabase;
import java.sql.SQLException;
import java.util.ArrayList;

public class Compare_Database
{

    public class CompareIT_Database implements ICompare_Database {

        private MyDatabase db;

        //    Fill out with your postgres password
        private static final String DRIVER = "org.postgresql.Driver";
        private static final String URL = "jdbc:postgresql://localhost:127.0.0.1:52015/browser/postgres";
        private static final String USER = "postgres";
        private static final String PASSWORD = "Poma23072016";


        public CompareIT_Database()
        {
            try
            {
                this.db = new MyDatabase(DRIVER, URL, USER, PASSWORD);

            } catch (ClassNotFoundException e)
            {
                e.printStackTrace();
            }
        }

        //The method simply creates a list of users from the database in order to be used in the model.

        public UserList loadUsers() throws SQLException
        {
            String person = "SELECT Users.username, Users.password,Users.firstname,Users.lastname,Users.email,Users.isAdmin,Wish.url " +
                    "FROM public.Users " +
                    "inner join Wish.url on Users.username = Wish.username;";
            UsersList list = new UsersList();
            ArrayList<Object[]> UsersList = db.query(user);
            for (int i = 0; i < UsersList.size(); i++)
            {
                Object[] array = UsersList.get(i);
                Users user = new Users(String.valueOf(array[0]), String.valueOf(array[1]),
                        String.valueOf(array[2]), String.valueOf(array[3]), String.valueOf(array[4])
                        , String.valueOf(array[5]), String.valueOf(array[6]));
                list.addUsers(user);
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
                list.addWish(wish);
            }
            return list;
        }

        //This is a private method which loads only one user by passing a username as an argument and return one user.

        private Users loadOneUser(String username) throws SQLException
        {
            String sql = "SELECT Users.username, Users.password,Users.firstname,Users.lastname,Users.email,Users.isAdmin,Wish.url " +
                    "FROM public.Users " +
                    "inner join Wish.url on Users.username = Wish.username WHERE User.username=?;";
            Users user = null;

            ArrayList<Object[]> user1 = db.query(sql, username);
            for (int i = 0; i < user1.size(); i++)
            {
                Object[] array = user1.get(i);
                user1 = new Users(array[0] + "", array[1] + "", array[2] + "", array[3] + "", array[4] + "", array[5] + "", array[6] + "");
            }
            return user;
        }

        //This method registers a new wish
        public synchronized void registerWish(Wish wish) throws SQLException
        {
            String newWish = "INSERT INTO public.Wish(url,username)" +
                    "VALUES( ?,?);";
            db.update(newWish, wish.getUsername(), wish.getURL());
        }

        //This method removes a wish
        public synchronized void removeWish(Wish wish) throws SQLException
        {
            String count = "SELECT COUNT(*) AS myRow FROM public.Wish WHERE Wish.username=?;";
            String sql = "DELETE FROM public.Wish where username=?;";
            int myCount = 0;

            ArrayList<Object[]> rows = db.query(count, wish.getUsername());
            myCount = Integer.parseInt(rows.get(0)[0].toString());
            if (myCount > 1)
            {
                db.update(sql, wish.getURL(), wish.getUsername());
            } else {

            }
        }

        //This method adds a user
        public synchronized void registerUser(Users user) throws SQLException
        {
            String person = "INSERT INTO public.User(username,password,firstname,lastname,email,isAdmin) VALUES (?,?,?,?,?,?);";
            db.update(person, wish.getUsername(), wish.getPassword(), wish.getFirstname(), wish.getLastname,wish.getEmail(),false);
            registerWish(wish);
        }


        //This method deletes a specific user
        public synchronized void removeUser(Users user) throws SQLException
        {
            String sql = "DELETE FROM public.Users WHERE username=?;";
            db.update(sql, user.getUsername());
        }

    }




}

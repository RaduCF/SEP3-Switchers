package DataPersistence;


import java.io.BufferedOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.sql.SQLException;

import com.google.gson.Gson;
import domain.User;


public class ServerBeClient {
    public static void main(String[] args) throws IOException, SQLException {
        final String HOST = "192.168.1.3";

        final int PORT = 6799;
        Gson gson = new Gson();
    Socket socket = new Socket(HOST, PORT);
        System.out.println("connecting to server");

 
    BufferedOutputStream out = new BufferedOutputStream(socket.getOutputStream());

   
   String us1="Ati";
     String repJson=gson.toJson(loadUser(us1));
    byte[] bytes = repJson.getBytes();
        out.write(bytes);
        out.flush();
}
    public static User loadUser(String username) throws SQLException {
        ICompare_Database database = new Compare_Database();
       return  ((Compare_Database) database).loadOneUser(username);
    }
}

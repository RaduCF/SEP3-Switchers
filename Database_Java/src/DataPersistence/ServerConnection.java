package DataPersistence;

import com.google.gson.Gson;
import domain.User;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.SQLException;

public class ServerConnection {


    public static void main(String[] args) throws IOException, SQLException {

        final int PORT = 6789;


        //code for server
        System.out.println("starting server...");
        ServerSocket welcome = new ServerSocket(PORT);
        while (true) {

            Gson gson = new Gson();
            Socket socket = welcome.accept();
            System.out.println("client connected");
            BufferedInputStream in = new BufferedInputStream(socket.getInputStream());
            BufferedOutputStream out = new BufferedOutputStream(socket.getOutputStream());

            ByteArrayOutputStream buf = new ByteArrayOutputStream();
            int result = in.read();
            while (result != -1) {
                buf.write((byte) result);
                result = in.read();
            }
            String byteArray = buf.toString();
            System.out.println("client...> " + byteArray);
            User receive = gson.fromJson(byteArray, User.class);
            register(receive);
            System.out.println(receive.toString());




        }


    }

    public static void register(User user) throws SQLException {
        ICompare_Database database = new Compare_Database();
        database.registerUser(user);
    }
}
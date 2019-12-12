package DataPersistence;

import com.google.gson.Gson;
import domain.User;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketException;
import java.sql.SQLException;

public class ServerConnection {

    public static void main(String[] args) throws IOException, SQLException {
        final int PORT = 6789;
        //code for server
        System.out.println("starting server...");
        ServerSocket welcome = new ServerSocket(PORT);
        System.out.println("Waiting for client...");
        try{  while (true) {
            Socket socket = welcome.accept();
            System.out.println("client connected");
            Thread clientThread = new Thread(new ClientHandler(socket));
            clientThread.start();}}
            catch(SocketException e){
                System.out.println("Connection problem!");
            }


    }
}
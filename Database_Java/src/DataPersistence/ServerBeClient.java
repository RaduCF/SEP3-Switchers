package DataPersistence;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.IOException;
import java.net.Socket;
import com.google.gson.Gson;


public class ServerBeClient {
    public static void main(String[] args) throws IOException {
        final String HOST = "10.152.208.46";

        final int PORT = 6799;
        Gson gson = new Gson();
    Socket socket = new Socket(HOST, PORT);
        System.out.println("connecting to server");

    BufferedInputStream in = new BufferedInputStream(socket.getInputStream());
    BufferedOutputStream out = new BufferedOutputStream(socket.getOutputStream());

    String rep = "client sends data to the server!";
     String repJson=gson.toJson(rep);
    byte[] bytes = repJson.getBytes();
        out.write(bytes);
        out.flush();
}}

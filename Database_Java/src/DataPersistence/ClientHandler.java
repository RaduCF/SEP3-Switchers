package DataPersistence;

import com.google.gson.*;
import com.mysql.jdbc.log.Log;
import domain.Login;
import domain.User;

import java.io.*;
import java.lang.reflect.Type;
import java.net.ServerSocket;
import java.net.Socket;
import java.sql.SQLException;

public class ClientHandler implements Runnable {

    //    private BufferedInputStream in;
//    private BufferedOutputStream out;
    private ICompare_Database database = new Compare_Database();

    private InputStream in;
    private OutputStream out;

    public ClientHandler(Socket socket) throws IOException {
        in = socket.getInputStream();
        out = socket.getOutputStream();


    }

    @Override
    public void run() {
        try {

            Gson gson = new Gson();
            //reading
            byte[] lenBytes = new byte[4];
            in.read(lenBytes, 0, 4);
            int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) |
                    ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
            byte[] receivedBytes = new byte[len];
            in.read(receivedBytes, 0, len);
            String received = new String(receivedBytes, 0, len);
            System.out.println("Server received: " + received);
            // User receive = gson.fromJson(received, User.class);
            Login receive = gson.fromJson(received, Login.class);

            System.out.println(receive.toString());
            //register(receive);
            boolean exist = validateLogin(receive.getID(), receive.getPassword());

            //send

            boolean reply = exist;
            String toSend = "Echo: " + reply;
            byte[] toSendBytes = toSend.getBytes();
            int toSendLen = toSendBytes.length;
            byte[] toSendLenBytes = new byte[4];
            toSendLenBytes[0] = (byte) (toSendLen & 0xff);
            toSendLenBytes[1] = (byte) ((toSendLen >> 8) & 0xff);
            toSendLenBytes[2] = (byte) ((toSendLen >> 16) & 0xff);
            toSendLenBytes[3] = (byte) ((toSendLen >> 24) & 0xff);
            out.write(toSendLenBytes);
            out.write(toSendBytes);


//            ByteArrayOutputStream buf = new ByteArrayOutputStream();
//            int result = in.read();
//            while (result != -1) {
//                buf.write((byte) result);
//                result = in.read();
//            }
//            String byteArray = buf.toString();
//            System.out.println("client...> " + byteArray);
//            Gson gson = new Gson();
//
//            User receive = gson.fromJson(byteArray, User.class);
//            System.out.println(receive.toString());

////            //reply
//            String reply= "Accepted!";
//            System.out.println("reply"+reply);
//            String replyJson=gson.toJson(reply);
//            byte[] bytes = replyJson.getBytes();
//            out.write(bytes);
//            out.flush();
//            System.out.println("done!");


        } catch (Exception e) {
            e.printStackTrace();
        }

    }


    public void register(User user) throws SQLException {
        database.registerUser(user);
    }

    public boolean validateLogin(String id, String password) throws SQLException {
        return database.validateLogin(id, password);
    }


}


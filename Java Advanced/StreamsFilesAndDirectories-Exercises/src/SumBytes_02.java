import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

public class SumBytes_02 {
    public static void main(String[] args) {
        String path = "C:\\Users\\User\\Desktop\\SoftUni\\Java Advanced\\StreamsFilesAndDirectories-Exercises\\04. Java-Advanced-Files-and-Streams-Exercises-Resources\\input.txt";

        long sum = 0;

        try (BufferedReader br = Files.newBufferedReader(Path.of(path))) {

            String line = br.readLine();

            while (line != null) {
                for (char c : line.toCharArray()) {
                    sum += c;
                }
                line = br.readLine();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
        System.out.println(sum);
    }
}

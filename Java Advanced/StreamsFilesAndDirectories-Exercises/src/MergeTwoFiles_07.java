import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

public class MergeTwoFiles_07 {
    public static void main(String[] args) {

        String inputPath1 = "C:\\Users\\User\\Desktop\\SoftUni\\Java Advanced\\StreamsFilesAndDirectories-Exercises\\04. Java-Advanced-Files-and-Streams-Exercises-Resources\\inputOne.txt";
        String inputPath2 = "C:\\Users\\User\\Desktop\\SoftUni\\Java Advanced\\StreamsFilesAndDirectories-Exercises\\04. Java-Advanced-Files-and-Streams-Exercises-Resources\\inputTwo.txt";
        String outputPath = "C:\\Users\\User\\Desktop\\SoftUni\\Java Advanced\\StreamsFilesAndDirectories-Exercises\\04. Java-Advanced-Files-and-Streams-Exercises-Resources\\output1.txt";


        try (BufferedReader reader1 = Files.newBufferedReader(Path.of(inputPath1));
             BufferedReader reader2 = Files.newBufferedReader(Path.of(inputPath2));
             BufferedWriter writer = Files.newBufferedWriter(Path.of(outputPath))) {

            String line = reader1.readLine();
            while (line != null) {
                writer.write(line);
                writer.newLine();
                line = reader1.readLine();
            }

            line = reader2.readLine();
            while (line != null) {
                writer.write(line);
                writer.newLine();
                line = reader2.readLine();
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}

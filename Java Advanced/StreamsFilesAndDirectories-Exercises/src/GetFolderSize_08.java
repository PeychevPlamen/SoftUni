import java.io.File;

public class GetFolderSize_08 {
    public static void main(String[] args) {

        String path = "C:\\Users\\User\\Desktop\\SoftUni\\Java Advanced\\StreamsFilesAndDirectories-Exercises\\04. Java-Advanced-Files-and-Streams-Exercises-Resources\\Exercises Resources";

        File directory = new File(path);
        int size = 0;
        if (directory.isDirectory()) {
            File[] files = directory.listFiles();

            for (File file : files) {
                if (!file.isDirectory()) {
                    size += file.length();
                }
            }
        }
        System.out.printf("Folder size: %d", size);
    }
}

import java.util.Scanner;
import java.util.function.Consumer;

public class KnightsOfHonor_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine(); //"Peter George Alex"
        String[] names = input.split("\\s+"); //["Peter", "George", "Alex"]

        Consumer<String[]> printArray = array -> {
            for (String name : array) {
                System.out.println("Sir " + name);
            }
        };

        printArray.accept(names);
    }
}

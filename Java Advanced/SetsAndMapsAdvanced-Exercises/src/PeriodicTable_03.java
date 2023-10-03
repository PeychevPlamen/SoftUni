import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeSet;

public class PeriodicTable_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        TreeSet<String> elements = new TreeSet<>();

        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split("\\s+");
            elements.addAll(Arrays.asList(input));
        }

        String result = String.join(" ", elements);
        System.out.println(result);
    }
}

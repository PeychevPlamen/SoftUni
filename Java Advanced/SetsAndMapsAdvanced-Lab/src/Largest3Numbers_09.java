import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Largest3Numbers_09 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        List<Integer> sorted = Arrays.stream(scanner.nextLine()
                        .split("\\s+"))
                .map(Integer::parseInt)
                .sorted(Comparator.reverseOrder())
                .collect(Collectors.toList());

        int count = 0;
        for (int i = 0; i < sorted.size(); i++) {
            if (i == 2) {
                System.out.print(sorted.get(i));
            } else {
                System.out.print(sorted.get(i) + " ");
            }
            count++;
            if (count == 3) {
                break;
            }
        }
    }
}


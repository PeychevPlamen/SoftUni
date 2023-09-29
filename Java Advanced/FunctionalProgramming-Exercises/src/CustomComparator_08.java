import java.util.*;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class CustomComparator_08 {
    public static void main(String[] args) {

        // comparator -> function accepts 2 parameters and return int(0, 1, -1)
        // 0 -> first == second
        // 1 -> first > second
        // -1 -> first < second

        // sorted(0) -> not swap the elements
        // sorted(1) -> swap the elements
        // sorted(-1) -> not swap the elements

        Scanner scanner = new Scanner(System.in);

        List<Integer> numbers = Arrays.stream(scanner.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        Comparator<Integer> customComparator = ((first, second) -> {
            // first even, second odd -> not swap
            if (first % 2 == 0 && second % 2 != 0) {
                return -1;
            }
            // first odd, second even -> swap
            else if (first % 2 != 0 && second % 2 == 0) {
                return 1;
            }
            // first even, second even
            // first odd, second odd
            else {
                return first.compareTo(second);
            }
        });

        numbers.stream().sorted(customComparator).forEach(number -> System.out.print(number + " "));
    }
}

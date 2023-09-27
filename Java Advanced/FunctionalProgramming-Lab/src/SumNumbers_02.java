import java.util.Arrays;
import java.util.Scanner;
import java.util.function.Function;

public class SumNumbers_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int[] numbers = Arrays.stream(scanner.nextLine().split(", "))
                .mapToInt(Integer::parseInt)
                .toArray();

        Function<int[], String> count = arr -> "Count = " + arr.length;
        Function<int[], String> sum = arr -> "Sum = " + Arrays.stream(arr).sum();

        System.out.println(count.apply(numbers));
        System.out.println(sum.apply(numbers));
    }
}

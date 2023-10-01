import java.util.Arrays;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class CountRealNumbers_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double[] input = Arrays.stream(scanner.nextLine()
                .split("\\s+"))
                .mapToDouble(Double::parseDouble)
                .toArray();

        Map<Double, Integer> numbersCount = new LinkedHashMap<>();

        for (double num : input) {
            if (numbersCount.containsKey(num)){
                numbersCount.put(num, numbersCount.get(num) + 1);
            } else {
                numbersCount.put(num, 1);
            }
        }

        for (Double key : numbersCount.keySet()){
            System.out.println(String.format("%.1f -> %d", key, numbersCount.get(key)));
        }
    }
}

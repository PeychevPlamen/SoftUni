import java.util.Arrays;
import java.util.Scanner;
import java.util.function.UnaryOperator;

public class AddVAT_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        System.out.println("Prices with VAT:");

        UnaryOperator<String> addVat = value -> String.format("%.2f", Double.parseDouble(value) * 1.2);

        Arrays.stream(scanner.nextLine().split(", "))
                .map(addVat)
                .forEach(System.out::println);
    }
}

import java.util.Scanner;

public class AccountBalance_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();
        double sum = 0;

        while (!input.equals("NoMoreMoney")) {

            if (Double.parseDouble(input) < 0) {
                System.out.println("Invalid operation!");
                break;
            }
            sum += Double.parseDouble(input);

            System.out.printf("Increase: %.2f%n", Double.parseDouble(input));
            input = scanner.nextLine();

        }
        System.out.printf("Total: %.2f", sum);

    }
}


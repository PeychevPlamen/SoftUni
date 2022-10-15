import java.util.Scanner;

public class Travelling_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String destination = scanner.nextLine();

        while (!destination.equals("End")) {

            double money = Double.parseDouble(scanner.nextLine());

            for (int i = 0; i < Integer.MAX_VALUE; i++) {
                double spentMoney = Double.parseDouble(scanner.nextLine());
                money -= spentMoney;
                if (money <= 0) {
                    System.out.printf("Going to %s!%n", destination);
                    break;
                }
            }

            destination = scanner.nextLine();
        }
    }
}

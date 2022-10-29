import java.util.Scanner;

public class GoldMine_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int location = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < location; i++) {

            double expectedAverageGoldPerDay = Double.parseDouble(scanner.nextLine());
            int days = Integer.parseInt(scanner.nextLine());
            double averageGold = 0;

            for (int j = 0; j < days; j++) {

                double goldPerDay = Double.parseDouble(scanner.nextLine());

                averageGold += goldPerDay;
            }

            averageGold /= days;

            if (averageGold >= expectedAverageGoldPerDay) {
                System.out.printf("Good job! Average gold per day: %.2f.%n", averageGold);
            } else {
                System.out.printf("You need %.2f gold.%n", expectedAverageGoldPerDay - averageGold);
            }

        }
    }
}

import java.util.Scanner;

public class CleverLily_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int age = Integer.parseInt(scanner.nextLine());
        double priceWash = Double.parseDouble(scanner.nextLine());
        int toyPrice = Integer.parseInt(scanner.nextLine());

        int toyCount = 0;
        int temp = 0;
        int money = 0;
        int brotherTake = 0;

        for (int i = 1; i <= age; i++) {
            if (i % 2 == 0) {
                temp +=10;
                money += temp;
                brotherTake++;
            } else {
                toyCount++;
            }
        }

        double moneyLeft = (money + toyCount * toyPrice - brotherTake) - priceWash;

        if (moneyLeft >= 0) {
            System.out.printf("Yes! %.2f", moneyLeft);
        } else {
            System.out.printf("No! %.2f", Math.abs(moneyLeft));
        }
    }
}

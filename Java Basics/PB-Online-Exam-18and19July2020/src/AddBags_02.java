import java.util.Scanner;

public class AddBags_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double priceOver20kg = Double.parseDouble(scanner.nextLine());
        double bagsKg = Double.parseDouble(scanner.nextLine());
        int daysToTrip = Integer.parseInt(scanner.nextLine());
        int bagsCount = Integer.parseInt(scanner.nextLine());

        double price = 0;

        if (bagsKg < 10) {
            price = priceOver20kg * 0.2;
        } else if (bagsKg <= 20) {
            price = priceOver20kg * 0.5;
        } else {
            price = priceOver20kg;
        }

        if (daysToTrip > 30) {
            price *= 1.1;
        } else if (daysToTrip >= 7) {
            price *= 1.15;
        } else {
            price *= 1.4;
        }

        double total = price * bagsCount;

        System.out.printf("The total price of bags is: %.2f lv.", total);
    }
}

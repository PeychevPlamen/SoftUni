import java.util.Scanner;

public class FishingBoat_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int budget = Integer.parseInt(scanner.nextLine());
        String season = scanner.nextLine();
        int fishermanCount = Integer.parseInt(scanner.nextLine());

        double total = 0.0;
        double price = 0.0;

        switch (season) {
            case "Spring":
                price = 3000;
                break;
            case "Summer":
            case "Autumn":
                price = 4200;
                break;
            case "Winter":
                price = 2600;
                break;
        }

        if (fishermanCount <= 6) {
            price *= 0.90;
        } else if (fishermanCount >= 7 && fishermanCount <= 11) {
            price *= 0.85;
        } else if (fishermanCount > 12) {
            price *= 0.75;
        }
        if (fishermanCount % 2 == 0 && !season.equals("Autumn")) {
            price *= 0.95;
        }

        total = budget - price;

        if (total >= 0){
            System.out.printf("Yes! You have %.2f leva left.", total);
        } else {
            System.out.printf("Not enough money! You need %.2f leva.", Math.abs(total));
        }
    }
}

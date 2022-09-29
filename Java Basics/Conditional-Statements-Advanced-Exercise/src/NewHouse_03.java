import java.util.Scanner;

public class NewHouse_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String flowerType = scanner.nextLine();
        int quantity = Integer.parseInt(scanner.nextLine());
        int budget = Integer.parseInt(scanner.nextLine());

        double total = 0.0;

        switch (flowerType) {
            case "Roses":
                total = quantity * 5;
                break;
            case "Dahlias":
                total = quantity * 3.80;
                break;
            case "Tulips":
                total = quantity * 2.80;
                break;
            case "Narcissus":
                total = quantity * 3.0;
                break;
            case "Gladiolus":
                total = quantity * 2.50;
                break;
        }

        if (quantity > 80 && flowerType.equals("Roses")) {
            total *= 0.90;
        } else if (quantity > 90 && flowerType.equals("Dahlias")) {
            total *= 0.85;
        } else if (quantity > 80 && flowerType.equals("Tulips")) {
            total *= 0.85;
        } else if (quantity < 120 && flowerType.equals("Narcissus")) {
            total *= 1.15;
        } else if (quantity < 80 && flowerType.equals("Gladiolus")) {
            total *= 1.20;
        }

        if (budget >= total) {
            System.out.printf("Hey, you have a great garden with %d %s " +
                    "and %.2f leva left.", quantity, flowerType, budget - total);
        } else {
            System.out.printf("Not enough money, you need %.2f leva more.", Math.abs(budget - total));
        }
    }
}

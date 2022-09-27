import java.util.Scanner;

public class Shopping_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        int videoCardsCount = Integer.parseInt(scanner.nextLine());
        int cpuCount = Integer.parseInt(scanner.nextLine());
        int ramMemoryCount = Integer.parseInt(scanner.nextLine());

        double videoCardPrice = 250.0;
        double cpuPrice = (videoCardsCount * videoCardPrice) * 0.35;
        double ramPrice = (videoCardPrice * videoCardsCount) * 0.1;

        double total = videoCardsCount * videoCardPrice
                + cpuCount * cpuPrice
                + ramMemoryCount * ramPrice;

        if (videoCardsCount > cpuCount) {
            total *= 0.85;
        }
        if (budget >= total) {
            System.out.printf("You have %.2f leva left!", budget - total);
        } else {
            System.out.printf("Not enough money! You need %.2f leva more!", Math.abs(budget - total));
        }
    }
}

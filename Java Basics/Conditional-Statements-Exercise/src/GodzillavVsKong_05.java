import java.util.Scanner;

public class GodzillavVsKong_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        int statists = Integer.parseInt(scanner.nextLine());
        double clothesPrice = Double.parseDouble(scanner.nextLine());

        double decorPrice = budget * 0.1;
        double totalClothesPrice = statists * clothesPrice;

        if (statists > 150) {
            totalClothesPrice -= totalClothesPrice * 0.1;
        }

        double totalMoney = budget - decorPrice - totalClothesPrice;

        if (totalMoney >= 0) {
            System.out.printf("Action!%n" +
                    "Wingard starts filming with %.2f leva left.", totalMoney);
        } else {
            totalMoney = Math.abs(totalMoney);
            System.out.printf("Not enough money!%n" +
                    "Wingard needs %.2f leva more.", totalMoney);
        }
    }
}

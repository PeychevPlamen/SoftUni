import java.util.Scanner;

public class ToyShop_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double puzzlePrice = 2.60;
        double dollPrice = 3.0;
        double bearPrice = 4.10;
        double minionPrice = 8.2;
        double truckPrice = 2.0;

        double tripPrice = Double.parseDouble(scanner.nextLine());
        int puzzles = Integer.parseInt(scanner.nextLine());
        int dolls = Integer.parseInt(scanner.nextLine());
        int bears = Integer.parseInt(scanner.nextLine());
        int minions = Integer.parseInt(scanner.nextLine());
        int trucks = Integer.parseInt(scanner.nextLine());

        int totalToysCount = puzzles + dolls + bears + minions + trucks;
        double totalPrice = puzzlePrice * puzzles
                + dollPrice * dolls
                + bearPrice * bears
                + minionPrice * minions
                + truckPrice * trucks;

        if (totalToysCount >= 50) {
            totalPrice *= 0.75;
        }

        totalPrice = totalPrice - totalPrice * 0.1;
        double extraMoney = totalPrice - tripPrice;

        if (extraMoney >= 0) {
            System.out.printf("Yes! %.02f lv left.", extraMoney);
        }else {
            extraMoney = Math.abs(extraMoney);
            System.out.printf("Not enough money! %.02f lv needed.", extraMoney);
        }
    }
}

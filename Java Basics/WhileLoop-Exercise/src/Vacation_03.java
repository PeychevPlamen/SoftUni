import java.util.Scanner;

public class Vacation_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double moneyNeeded = Double.parseDouble(scanner.nextLine());
        double money = Double.parseDouble(scanner.nextLine());

        boolean isBroke = false;

        int counter = 0;
        int days = 0;

        while (money < moneyNeeded) {

            String text = scanner.nextLine();
            double spendSaveMoney = Double.parseDouble(scanner.nextLine());

            days++;

            switch (text) {
                case "spend":
                    money -= spendSaveMoney;
                    if (money < 0) {
                        money = 0;
                    }
                    counter++;
                    break;
                case "save":
                    money += spendSaveMoney;
                    counter = 0;
                    break;
            }
            if (counter == 5) {
                isBroke = true;
                break;
            }

        }
        if (isBroke) {
            System.out.printf("You can't save the money.%n%d", days);
        }
        if (money >= moneyNeeded) {
            System.out.printf("You saved the money for %d days.", days);
        }
    }
}

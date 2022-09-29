import java.util.Scanner;

public class FruitShop_11 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String fruit = scanner.nextLine();
        String dayOfWeek = scanner.nextLine();
        double quantity = Double.parseDouble(scanner.nextLine());

        double price = 0;

        if (fruit.equals("banana")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 2.5;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 2.7;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("apple")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 1.2;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 1.25;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("orange")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 0.85;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 0.9;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("grapefruit")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 1.45;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 1.6;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("kiwi")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 2.7;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 3.0;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("pineapple")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 5.5;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 5.6;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else if (fruit.equals("grapes")) {
            switch (dayOfWeek) {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    price = 3.85;
                    break;
                case "Saturday":
                case "Sunday":
                    price = 4.2;
                    break;
                default:
                    System.out.println("error");
                    break;
            }
            if (price != 0) {
                System.out.printf("%.2f", quantity * price);
            }
        } else {
            System.out.println("error");
        }
    }
}

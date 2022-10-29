import java.util.Scanner;

public class ComputerRoom_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String month = scanner.nextLine();
        int hoursSpent = Integer.parseInt(scanner.nextLine());
        int peopleCount = Integer.parseInt(scanner.nextLine());
        String dayTime = scanner.nextLine();

        double pricePerHour = 0;

        switch (month) {
            case "march":
            case "april":
            case "may":
                if (dayTime.equals("day")) {
                    pricePerHour = 10.50;
                } else {
                    pricePerHour = 8.40;
                }
                break;
            case "june":
            case "july":
            case "august":
                if (dayTime.equals("day")) {
                    pricePerHour = 12.60;
                } else {
                    pricePerHour = 10.20;
                }
                break;
            default:
                break;
        }

        if (peopleCount >= 4) {
            pricePerHour *= 0.90;
        }
        if (hoursSpent >= 5) {
            pricePerHour *= 0.5;
        }

        double total = pricePerHour * peopleCount * hoursSpent;

        System.out.printf("Price per person for one hour: %.2f%n" +
                "Total cost of the visit: %.2f", pricePerHour, total);
    }
}

import java.util.Scanner;

public class HotelRoom_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String months = scanner.nextLine();
        int nights = Integer.parseInt(scanner.nextLine());

        double totalApartment = 0;
        double totalStudio = 0;

        if (months.equals("May") || months.equals("October")) {
            totalStudio = nights * 50;
            totalApartment = nights * 65;

            if (nights > 14) {
                totalStudio *= 0.70;
                totalApartment *= 0.90;
            } else if (nights > 7) {
                totalStudio *= 0.95;
            }
        } else if (months.equals("June") || months.equals("September")) {
            totalStudio = nights * 75.20;
            totalApartment = nights * 68.70;
            if (nights > 14) {
                totalStudio *= 0.80;
                totalApartment *= 0.90;
            }
        } else if (months.equals("July") || months.equals("August")) {
            totalStudio = nights * 76;
            totalApartment = nights * 77;
            if (nights > 14) {
                totalApartment *= 0.90;
            }
        }
        System.out.printf("Apartment: %.2f lv.%n" +
                "Studio: %.2f lv.", totalApartment, totalStudio);
    }
}

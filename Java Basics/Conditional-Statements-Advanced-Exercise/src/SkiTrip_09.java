import java.util.Scanner;

public class SkiTrip_09 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        String place = scanner.nextLine();
        String grade = scanner.nextLine();

        int nights = days - 1;
        double total = 0.0;

        if (place.equals("room for one person")) {
            total = nights * 18;
        } else if (place.equals("apartment")) {
            if (days < 10) {
                total = nights * 25 * 0.70;
            } else if (days < 15) {
                total = nights * 25 * 0.65;
            } else {
                total = nights * 25 * 0.50;
            }
        } else if (place.equals("president apartment")) {
            if (days < 10) {
                total = nights * 35 * 0.90;
            } else if (days < 15) {
                total = nights * 35 * 0.85;
            } else {
                total = nights * 35 * 0.80;
            }
        }
        switch (grade) {
            case "positive":
                total += total * 0.25;
                break;
            case "negative":
                total -= total * 0.1;
        }
        System.out.printf("%.2f", total);
    }
}

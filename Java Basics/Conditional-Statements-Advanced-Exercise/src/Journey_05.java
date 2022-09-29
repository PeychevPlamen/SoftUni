import java.util.Scanner;

public class Journey_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        String season = scanner.nextLine();

        String destination = "";
        String place = "";
        double total = 0.0;

        if (budget <= 100) {
            destination = "Bulgaria";
            switch (season) {
                case "summer":
                    total = budget * 0.3;
                    place = "Camp";
                    break;
                case "winter":
                    total = budget * 0.7;
                    place = "Hotel";
                    break;
            }
        } else if (budget <= 1000) {
            destination = "Balkans";
            switch (season) {
                case "summer":
                    total = budget * 0.4;
                    place = "Camp";
                    break;
                case "winter":
                    total = budget * 0.8;
                    place = "Hotel";
                    break;
            }
        } else if (budget > 1000) {
            destination = "Europe";
            switch (season) {
                case "summer":
                case "winter":
                    total = budget * 0.9;
                    place = "Hotel";
                    break;
            }
        }
        System.out.printf("Somewhere in %s%n%s - %.2f", destination, place, total);
    }
}

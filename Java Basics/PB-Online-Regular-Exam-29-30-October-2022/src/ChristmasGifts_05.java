import java.util.Scanner;

public class ChristmasGifts_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        int toyPrice = 5;
        int sweatersPrice = 15;
        int kids = 0;
        int adults = 0;

        while (!input.equals("Christmas")) {

            int age = Integer.parseInt(input);

            if (age <= 16) {
                kids++;
            } else {
                adults++;
            }

            input = scanner.nextLine();
        }
        System.out.printf("Number of adults: %d%n", adults);
        System.out.printf("Number of kids: %d%n", kids);
        System.out.printf("Money for toys: %d%n", kids * toyPrice);
        System.out.printf("Money for sweaters: %d%n", adults * sweatersPrice);
    }
}

import java.util.Scanner;

public class PCGameShop_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        double countHearthstone = 0;
        double countFornite = 0;
        double countOverwatch = 0;
        double countOthers = 0;

        for (int i = 0; i < n; i++) {

            String game = scanner.nextLine();

            if (game.equals("Hearthstone")) {
                countHearthstone++;
            } else if (game.equals("Fornite")) {
                countFornite++;
            } else if (game.equals("Overwatch")) {
                countOverwatch++;
            } else {
                countOthers++;
            }
        }

        System.out.printf("Hearthstone - %.2f%%%n", countHearthstone / n * 100);
        System.out.printf("Fornite - %.2f%%%n", countFornite / n * 100);
        System.out.printf("Overwatch - %.2f%%%n", countOverwatch / n * 100);
        System.out.printf("Others - %.2f%%%n", countOthers / n * 100);

    }
}

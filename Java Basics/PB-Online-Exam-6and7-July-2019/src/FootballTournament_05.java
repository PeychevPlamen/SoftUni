import java.util.Scanner;

public class FootballTournament_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();
        int games = Integer.parseInt(scanner.nextLine());

        int wCount = 0;
        int dCount = 0;
        int lCount = 0;
        int totalPoints = 0;

        if (games > 0) {
            for (int i = 0; i < games; i++) {

                String input = scanner.nextLine();

                if (input.equals("W")) {
                    totalPoints += 3;
                    wCount++;
                } else if (input.equals("D")) {
                    totalPoints += 1;
                    dCount++;
                } else if (input.equals("L")) {
                    lCount++;
                }
            }

            double winRate = 1.0 * wCount / games * 100;

            System.out.printf("%s has won %d points during this season.%n", name, totalPoints);
            System.out.printf("Total stats:%n" +
                    "## W: %d%n" +
                    "## D: %d%n" +
                    "## L: %d%n", wCount, dCount, lCount);
            System.out.printf("Win rate: %.2f%%", winRate);

        }else {
            System.out.printf("%s hasn't played any games during this season.", name);
        }

    }
}

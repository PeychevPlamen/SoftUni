import java.util.Scanner;

public class TennisRanklist_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int turnaments = Integer.parseInt(scanner.nextLine());
        int points = Integer.parseInt(scanner.nextLine());

        int winner = 0;
        int currPoints = 0;

        for (int i = 0; i < turnaments; i++) {

            String stage = scanner.nextLine();

            switch (stage) {
                case "W":
                    winner++;
                    currPoints += 2000;
                    break;
                case "F":
                    currPoints += 1200;
                    break;
                case "SF":
                    currPoints += 720;
                    break;
            }

        }
        int totalPoints = currPoints + points;
        double percent = (1.0 * winner / turnaments) * 100;
        double averagePoints = Math.floor(1.0 * currPoints / turnaments);

        System.out.printf("Final points: %d%nAverage points: %.0f%n%.2f%%", totalPoints, averagePoints, percent);

    }
}

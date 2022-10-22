import java.util.Scanner;

public class NameGame_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        int points = 0;
        int winnerPoints = 0;
        String winnerName = "";

        while (!input.equals("Stop")) {

            for (int i = 0; i < input.length(); i++) {

                int num = Integer.parseInt(scanner.nextLine());
                int asciNum = input.charAt(i);

                if (num == asciNum) {
                    points += 10;
                } else {
                    points += 2;
                }
            }
            if (points >= winnerPoints) {
                winnerPoints = points;
                winnerName = input;
            }
            points = 0;
            input = scanner.nextLine();
        }

        System.out.printf("The winner is %s with %d points!", winnerName, winnerPoints);
    }
}

import java.util.Scanner;

public class Oscars_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String actorName = scanner.nextLine();
        double actorPoints = Double.parseDouble(scanner.nextLine());
        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String name = scanner.nextLine();
            double points = Double.parseDouble(scanner.nextLine());
            int count = name.length();
            actorPoints += count * points / 2;

            if (actorPoints >= 1250.5) {
                break;
            }
        }
        if (actorPoints < 1250.5) {
            System.out.printf("Sorry, %s you need %.1f more!", actorName, 1250.5 - actorPoints);
        } else {
            System.out.printf("Congratulations, %s got a nominee for leading role with %.1f!", actorName, actorPoints);
        }
    }
}

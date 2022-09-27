import java.util.Scanner;

public class LunchBreak_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();
        int seriesLength = Integer.parseInt(scanner.nextLine());
        int brakeLength = Integer.parseInt(scanner.nextLine());

        double lunch = brakeLength / 8.0;
        double restTime = brakeLength / 4.0;
        double totalTimeBrake = brakeLength - lunch - restTime;

        if (seriesLength > totalTimeBrake) {
            System.out.printf("You don't have enough time to watch %s, " +
                    "you need %.0f more minutes.", name, Math.ceil(seriesLength - totalTimeBrake));
        } else {
            System.out.printf("You have enough time to watch %s " +
                    "and left with %.0f minutes free time.", name, Math.ceil(totalTimeBrake - seriesLength));
        }
    }
}

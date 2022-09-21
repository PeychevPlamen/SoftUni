import java.util.Scanner;

public class WorldSwimmingRecord_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double record = Double.parseDouble(scanner.nextLine());
        double distanceMeters = Double.parseDouble(scanner.nextLine());
        double timeInSecondsPerMeter = Double.parseDouble(scanner.nextLine());

        double totalTimeSeconds = distanceMeters * timeInSecondsPerMeter;

        double timePlus15Seconds = Math.floor(distanceMeters / 15) * 12.5;
        double totalTime = totalTimeSeconds + timePlus15Seconds;

        if (totalTime < record) {
            System.out.printf("Yes, he succeeded! The new world record is %.2f seconds.", totalTime);
        } else {
            totalTime = totalTime - record;
            System.out.printf("No, he failed! He was %.2f seconds slower.", totalTime);
        }
    }
}

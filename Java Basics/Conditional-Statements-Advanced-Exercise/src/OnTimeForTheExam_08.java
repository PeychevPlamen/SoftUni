import java.util.Scanner;

public class OnTimeForTheExam_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int examHour = Integer.parseInt(scanner.nextLine());
        int examMinutes = Integer.parseInt(scanner.nextLine());
        int arriveHour = Integer.parseInt(scanner.nextLine());
        int arriveMinutes = Integer.parseInt(scanner.nextLine());

        int totalMinExam = examHour * 60 + examMinutes;
        int totalMinArrive = arriveHour * 60 + arriveMinutes;
        int difference = totalMinExam - totalMinArrive;

        int hour = 0;
        int minutes = 0;

        if (totalMinExam >= totalMinArrive) {
            if (difference == 0) {
                System.out.println("On time");
            } else if (difference <= 30) {
                System.out.println("On time");
                System.out.printf("%d minutes before the start", Math.abs(difference));
            } else if (difference < 60) {
                System.out.println("Early");
                System.out.printf("%d minutes before the start", Math.abs(difference));
            } else {
                hour = difference / 60;
                minutes = difference % 60;
                System.out.println("Early");
                System.out.printf("%d:%02d hours before the start", hour, minutes);
            }
        } else {
            if (Math.abs(difference) < 60) {
                System.out.println("Late");
                System.out.printf("%d minutes after the start", Math.abs(difference));
            } else {
                hour = Math.abs(difference) / 60;
                minutes = Math.abs(difference) % 60;
                System.out.println("Late");
                System.out.printf("%d:%02d hours after the start", hour, minutes);
            }
        }
    }
}
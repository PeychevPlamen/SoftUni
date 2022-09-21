import java.util.Scanner;

public class TimePlus15Minutes_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int hours = Integer.parseInt(scanner.nextLine());
        int minutes = Integer.parseInt(scanner.nextLine());

        int plus15Minutes = minutes + 15;
        int totalHours;
        int totalMinutes;

        if (plus15Minutes > 59){
            totalHours = hours + 1;
            totalMinutes = plus15Minutes - 60;
        }else {
            totalHours = hours;
            totalMinutes = plus15Minutes;
        }
        if (totalHours > 23){
            totalHours = 0;
        }

        System.out.printf("%d:%02d", totalHours, totalMinutes);
    }
}

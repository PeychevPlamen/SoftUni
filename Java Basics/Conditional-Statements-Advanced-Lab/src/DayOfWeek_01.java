import java.util.Scanner;

public class DayOfWeek_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int dayOfWeekNum = Integer.parseInt(scanner.nextLine());

        //switch (dayOfWeekNum) {
        //            case 1 -> System.out.println("Monday");
        //            case 2 -> System.out.println("Tuesday");
        //            case 3 -> System.out.println("Wednesday");
        //            case 4 -> System.out.println("Thursday");
        //            case 5 -> System.out.println("Friday");
        //            case 6 -> System.out.println("Saturday");
        //            case 7 -> System.out.println("Sunday");
        //            default -> System.out.println("Error");

        switch (dayOfWeekNum){
            case 1:
                System.out.println("Monday");
                break;
            case 2:
                System.out.println("Tuesday");
                break;
            case 3:
                System.out.println("Wednesday");
                break;
            case 4:
                System.out.println("Thursday");
                break;
            case 5:
                System.out.println("Friday");
                break;
            case 6:
                System.out.println("Saturday");
                break;
            case 7:
                System.out.println("Sunday");
                break;
            default:
                System.out.println("Error");
                break;
        }
    }
}
import java.util.Scanner;

public class VacationBooksList_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Integer pagesInBook = Integer.parseInt(scanner.nextLine());
        Integer pagesPerHour = Integer.parseInt(scanner.nextLine());
        int daysNeeded = Integer.parseInt(scanner.nextLine());

        int timeForReadBook = pagesInBook / pagesPerHour;
        int neededHoursPerDay = timeForReadBook / daysNeeded;

        System.out.println(neededHoursPerDay);
    }
}

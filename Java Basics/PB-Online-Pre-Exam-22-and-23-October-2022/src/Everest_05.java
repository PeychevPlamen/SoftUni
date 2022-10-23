import java.util.Scanner;

public class Everest_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String text = scanner.nextLine();


        int start = 5364;
        int end = 8848;
        int daysCount = 1;
        boolean isFaild = false;

        while (!text.equals("END")) {

            int meters = Integer.parseInt(scanner.nextLine());

            if (text.equals("Yes")) {
                daysCount++;
            }
            if (daysCount > 5) {
                isFaild = true;
                break;
            }

            start += meters;

            if (start >= end) {
                break;
            }

            text = scanner.nextLine();
        }

        if (isFaild || start < end) {
            System.out.println("Failed!");
            System.out.printf("%d", start);
        } else {
            System.out.printf("Goal reached for %d days!", daysCount);
        }
    }
}

import java.util.Scanner;

public class Graduation_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String name = scanner.nextLine();

        double average = 0;
        int count = 0;
        int level = 0;

        while (level < 12) {
            double grade = Double.parseDouble(scanner.nextLine());

            if (grade < 4.00) {
                count++;
                if (count > 1) {
                    System.out.printf("%s has been excluded at %d grade", name, level);
                    break;
                }
                level++;
                continue;
            }

            level++;
            average += grade;
        }
        if (count < 2) {
            System.out.printf("%s graduated. Average grade: %.2f", name, average / level);
        }
    }
}

import java.util.Scanner;

public class Cinema_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String projection = scanner.nextLine();
        int rows = Integer.parseInt(scanner.nextLine());
        int cols = Integer.parseInt(scanner.nextLine());

        double income = 0.0;

        if (projection.equals("Premiere")) {
            income = rows * cols * 12.00;
        } else if (projection.equals("Normal")) {
            income = rows * cols * 7.50;
        } else if (projection.equals("Discount")) {
            income = rows * cols * 5.00;
        }
        System.out.printf("%.2f leva", income);
    }
}

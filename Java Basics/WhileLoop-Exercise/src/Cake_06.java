import java.util.Scanner;

public class Cake_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n1 = Integer.parseInt(scanner.nextLine());
        int n2 = Integer.parseInt(scanner.nextLine());
        int totalCake = n1 * n2;
        int count = 0;

        String input = scanner.nextLine();

        while (!input.equals("STOP")) {
            int piece = Integer.parseInt(input);
            count += piece;

            if (totalCake <= 0 || totalCake <= count) {
                break;
            }

            input = scanner.nextLine();
        }
        if (totalCake <= count) {
            System.out.printf("No more cake left! You need %d pieces more.", Math.abs(totalCake - count));
        } else {
            System.out.printf("%d pieces are left.", totalCake - count);
        }
    }
}

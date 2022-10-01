import java.util.Scanner;

public class LeftAndRightSum_09 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int sum1 = 0;
        int sum2 = 0;

        for (int i = 0; i < n; i++) {
            int num1 = Integer.parseInt(scanner.nextLine());

            sum1 += num1;
        }
        for (int j = 0; j < n; j++) {
            int num2 = Integer.parseInt(scanner.nextLine());

            sum2 += num2;
        }
        int diff = sum1 - sum2;

        if (diff == 0) {
            System.out.printf("Yes, sum = %d", sum1);
        } else {
            System.out.printf("No, diff = %d", Math.abs(diff));
        }
    }
}

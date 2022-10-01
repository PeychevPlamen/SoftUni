import java.util.Scanner;

public class OddEvenSum_10 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int sum1 = 0;
        int sum2 = 0;

        for (int i = 0; i < n; i++) {
            int num = Integer.parseInt(scanner.nextLine());

            if (i % 2 == 0) {
                sum1 += num;
            } else {
                sum2 += num;
            }
        }
        int diff = sum1 - sum2;

        if (diff == 0) {
            System.out.printf("Yes%n" +
                    "Sum = %d", sum1);
        } else {
            System.out.printf("No%n" +
                    "Diff = %d", Math.abs(diff));
        }
    }
}

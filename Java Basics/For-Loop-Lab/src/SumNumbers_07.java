import java.util.Scanner;

public class SumNumbers_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int numCount = Integer.parseInt(scanner.nextLine());
        int sum = 0;

        for (int i = 0; i < numCount; i++) {
            int num = Integer.parseInt(scanner.nextLine());
            sum += num;
        }
        System.out.println(sum);
    }
}

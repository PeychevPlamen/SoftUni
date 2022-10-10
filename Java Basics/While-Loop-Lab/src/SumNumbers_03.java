import java.awt.*;
import java.util.Scanner;

public class SumNumbers_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());
        int sum = 0;

        while (num > sum) {
            int input = Integer.parseInt(scanner.nextLine());
            sum += input;
        }

        System.out.println(sum);
    }
}

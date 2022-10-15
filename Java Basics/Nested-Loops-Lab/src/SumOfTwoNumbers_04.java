import java.util.Scanner;

public class SumOfTwoNumbers_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int start = Integer.parseInt(scanner.nextLine());
        int end = Integer.parseInt(scanner.nextLine());
        int magicNum = Integer.parseInt(scanner.nextLine());

        int num = 0;
        int count = 0;
        int firstNum = 0;
        int secondNum = 0;
        boolean isFind = false;

        for (int i = start; i <= end; i++) {
            for (int j = start; j <= end; j++) {
                firstNum = i;
                secondNum = j;
                num = firstNum + secondNum;
                count++;
                if (num == magicNum) {
                    isFind = true;
                    break;
                }
            }
            if (isFind) {
                break;
            }
        }
        if (isFind) {
            System.out.printf("Combination N:%d (%d + %d = %d)", count, firstNum, secondNum, magicNum);

        } else {
            System.out.printf("%d combinations - neither equals %d", count, magicNum);

        }
    }
}

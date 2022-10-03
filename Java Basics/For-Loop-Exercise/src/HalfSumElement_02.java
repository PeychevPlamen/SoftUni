import java.util.Scanner;

public class HalfSumElement_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int nums = Integer.parseInt(scanner.nextLine());
        int maxNum = Integer.MIN_VALUE;
        int sum = 0;

        for (int i = 0; i < nums; i++) {
            int num = Integer.parseInt(scanner.nextLine());
            sum += num;

            if (num > maxNum){
                maxNum = num;
            }
        }

        int equal = sum - maxNum;
        int diff = equal - maxNum;

        if (diff == 0){
            System.out.printf("Yes%n" + "Sum = %d", maxNum);
        }else {
            System.out.printf("No%n" + "Diff = %d", Math.abs(diff));
        }

    }
}

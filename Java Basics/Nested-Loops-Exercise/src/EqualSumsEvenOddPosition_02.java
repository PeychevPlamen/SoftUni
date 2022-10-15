import java.util.Scanner;

public class EqualSumsEvenOddPosition_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n1 = Integer.parseInt(scanner.nextLine());
        int n2 = Integer.parseInt(scanner.nextLine());

        for (int i = n1; i <= n2; i++) {

            String num = String.valueOf(i);

            int evenSum = 0;
            int oddSum = 0;
            int tempNum = 0;

            for (int j = 0; j < num.length(); j++) {
                if (j % 2 == 0) {
                    tempNum = Integer.parseInt(String.valueOf(num.charAt(j)));
                    evenSum += tempNum;
                } else {
                    tempNum = Integer.parseInt(String.valueOf(num.charAt(j)));
                    oddSum += tempNum;
                }
            }
            if (evenSum == oddSum) {
                System.out.printf("%s ", num);
            }
        }
    }
}

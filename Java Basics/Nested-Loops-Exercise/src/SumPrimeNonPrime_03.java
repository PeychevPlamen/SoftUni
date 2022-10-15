import java.util.Scanner;

public class SumPrimeNonPrime_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        int sumPrime = 0;
        int sumNonPrime = 0;

        while (!input.equals("stop")) {

            int num = Integer.parseInt(input);
            boolean isNonPrime = false;

            if (num <= 1) {
                isNonPrime = true;
            }
            for (int i = 2; i <= num / 2; i++) {
                if (num % i == 0) {
                    isNonPrime = true;
                }
            }
            if (num < 0) {
                System.out.println("Number is negative.");
            } else if (isNonPrime) {
                sumNonPrime += num;
            } else {
                sumPrime += num;
            }

            input = scanner.nextLine();
        }
        System.out.printf("Sum of all prime numbers is: %d%n" +
                "Sum of all non prime numbers is: %d", sumPrime, sumNonPrime);
    }
}

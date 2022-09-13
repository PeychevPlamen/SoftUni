import java.util.Scanner;

public class DepositCalculator_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double deposit = Double.parseDouble(scanner.nextLine());
        int months = Integer.parseInt(scanner.nextLine());
        double interestRate = Double.parseDouble(scanner.nextLine());
        
        Double sum = deposit + months * ((deposit * interestRate/100) / 12);

        System.out.printf("%.2f", sum);
    }
}

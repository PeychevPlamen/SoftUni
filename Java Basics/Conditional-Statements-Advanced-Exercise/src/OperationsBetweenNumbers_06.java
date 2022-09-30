import java.util.Scanner;

public class OperationsBetweenNumbers_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n1 = Integer.parseInt(scanner.nextLine());
        int n2 = Integer.parseInt(scanner.nextLine());
        String operator = scanner.nextLine();

        double result = 0;
        String oddOrEven = "";

        switch (operator) {
            case "+":
                result = n1 + n2;
                if (result % 2 == 0){
                    oddOrEven = "even";
                } else {
                    oddOrEven = "odd";
                }
                break;
            case "-":
                result = n1 - n2;
                if (result % 2 == 0){
                    oddOrEven = "even";
                } else {
                    oddOrEven = "odd";
                }
                break;
            case "*":
                result = n1 * n2;
                if (result % 2 == 0){
                    oddOrEven = "even";
                } else {
                    oddOrEven = "odd";
                }
                break;
            case "/":
                if (n2 == 0){
                    System.out.printf("Cannot divide %d by zero", n1);
                    break;
                }
                result = 1.0 * n1 / n2;
                break;
            case "%":
                if (n2 == 0){
                    System.out.printf("Cannot divide %d by zero", n1);
                    break;
                }
                result = n1 % n2;
                break;
        }
        if (operator.equals("+") || operator.equals("-") || operator.equals("*")){
            System.out.printf("%d %s %d = %.0f - %s", n1, operator, n2, result, oddOrEven);
        } else if (operator.equals("/") && n2 != 0) {
            System.out.printf("%d / %d = %.2f", n1, n2, result);
        } else if (operator.equals("%") && n2 != 0) {
            System.out.printf("%d %s %d = %.0f", n1, operator, n2, result);
        }
    }
}

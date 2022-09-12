import java.util.Scanner;

public class InchesToCentimeters_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double input = Double.parseDouble(scanner.nextLine());
        double inch = 2.54;

        double output = input * inch;

        System.out.println(output);
    }
}

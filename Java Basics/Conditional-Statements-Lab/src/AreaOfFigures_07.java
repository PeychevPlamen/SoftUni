import java.util.Scanner;

public class AreaOfFigures_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String figureInput = scanner.nextLine();
        double output = 0.0;

        if (figureInput.equals("square")) {

            double inputNum = Double.parseDouble(scanner.nextLine());
            output = Math.pow(inputNum, 2);

        } else if (figureInput.equals("rectangle")) {

            double a = Double.parseDouble(scanner.nextLine());
            double b = Double.parseDouble(scanner.nextLine());
            output = a * b;

        } else if (figureInput.equals("circle")) {

            double inputNum = Double.parseDouble(scanner.nextLine());
            output = Math.PI * Math.pow(inputNum, 2);

        } else if (figureInput.equals("triangle")) {

            double a = Double.parseDouble(scanner.nextLine());
            double h = Double.parseDouble(scanner.nextLine());
            output = a * h / 2;
        }

        System.out.printf("%.3f", output);
    }
}

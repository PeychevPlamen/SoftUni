import java.util.Scanner;

public class RadiansToDegrees_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        double input = Double.parseDouble(scanner.nextLine());

        Double output = input * 180/Math.PI;

        System.out.println(output);
    }
}

import java.util.Scanner;

public class GrandpaStavri_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        double totalRakia = 0;
        double totalGradus = 0;

        for (int i = 0; i < days; i++) {

            double rakia = Double.parseDouble(scanner.nextLine());
            double gradus = Double.parseDouble(scanner.nextLine());

            totalRakia += rakia;
            totalGradus += rakia * gradus;
        }

        double gradusOutput = totalGradus / totalRakia;

        System.out.printf("Liter: %.2f%n", totalRakia);
        System.out.printf("Degrees: %.2f%n", gradusOutput);

        if (gradusOutput < 38){
            System.out.println("Not good, you should baking!");
        } else if ( gradusOutput <= 42) {
            System.out.println("Super!");
        } else {
            System.out.println("Dilution with distilled water!");
        }
    }
}

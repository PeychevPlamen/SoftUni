import java.util.Scanner;

public class TradeCommissions_12 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String town = scanner.nextLine();
        double sales = Double.parseDouble(scanner.nextLine());

        double output = 0;

        if (town.equals("Sofia")) {
            if (sales >= 0 && sales <= 500) {
                output = sales * 0.05;
            } else if (sales > 500 && sales <= 1000) {
                output = sales * 0.07;
            } else if (sales > 1000 && sales <= 10000) {
                output = sales * 0.08;
            } else if (sales > 10000) {
                output = sales * 0.12;
            } else {
                System.out.println("error");
            }
        } else if (town.equals("Varna")) {
            if (sales >= 0 && sales <= 500) {
                output = sales * 0.045;
            } else if (sales > 500 && sales <= 1000) {
                output = sales * 0.075;
            } else if (sales > 1000 && sales <= 10000) {
                output = sales * 0.1;
            } else if (sales > 10000) {
                output = sales * 0.13;
            } else {
                System.out.println("error");
            }
        } else if (town.equals("Plovdiv")) {
            if (sales >= 0 && sales <= 500) {
                output = sales * 0.055;
            } else if (sales > 500 && sales <= 1000) {
                output = sales * 0.08;
            } else if (sales > 1000 && sales <= 10000) {
                output = sales * 0.12;
            } else if (sales > 10000) {
                output = sales * 0.145;
            } else {
                System.out.println("error");
            }
        } else {
            System.out.println("error");
        }
        if (output != 0) {
            System.out.printf("%.2f", output);
        }
    }
}

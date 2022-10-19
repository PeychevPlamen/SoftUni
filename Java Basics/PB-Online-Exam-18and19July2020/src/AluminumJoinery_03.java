import java.util.Scanner;

public class AluminumJoinery_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int count = Integer.parseInt(scanner.nextLine());
        String type = scanner.nextLine();
        String delivery = scanner.nextLine();

        double price = 0;

        if (count < 10) {
            System.out.println("Invalid order");
        } else {
            switch (type) {
                case "90X130":
                    if (count > 30 && count <= 60) {
                        price = 110 * count * 0.95;
                    } else if (count > 60) {
                        price = 110 * count * 0.92;
                    } else {
                        price = 110 * count;
                    }
                    break;
                case "100X150":
                    if (count > 40 && count <= 80) {
                        price = 140 * count * 0.94;
                    } else if (count > 80) {
                        price = 140 * count * 0.90;
                    } else {
                        price = 140 * count;
                    }
                    break;
                case "130X180":
                    if (count > 20 && count <= 50) {
                        price = 190 * count * 0.93;
                    } else if (count > 50) {
                        price = 190 * count * 0.88;
                    } else {
                        price = 190 * count;
                    }
                    break;
                case "200X300":
                    if (count > 25 && count <= 50) {
                        price = 250 * count * 0.91;
                    } else if (count > 50) {
                        price = 250 * count * 0.86;
                    } else {
                        price = 250 * count;
                    }
                    break;
            }
            if (delivery.equals("With delivery")) {
                price += 60;
            }
            if (count > 99) {
                price *= 0.96;
            }

            System.out.printf("%.2f BGN", price);
        }

    }
}

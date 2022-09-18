import java.util.Scanner;

public class BasketballEquipment_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int price = Integer.parseInt(scanner.nextLine());

        double sneakers = price * 0.6;
        double jersey = sneakers * 0.8;
        double ball = jersey * 0.25;
        double accessories = ball * 0.2;

        double total = price + sneakers + jersey + ball + accessories;

        System.out.println(total);

    }
}

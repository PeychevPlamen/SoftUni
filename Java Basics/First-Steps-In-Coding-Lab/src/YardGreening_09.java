import java.util.Scanner;

public class YardGreening_09 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double pricePerMeter = 7.61;
        Double meters = Double.parseDouble(scanner.nextLine());
        double discount = (pricePerMeter * meters) * 0.18;
        Double priceAfterDiscount = (pricePerMeter * meters) - discount;

        System.out.printf("The final price is: %.2f lv." +
                "%nThe discount is: %.2f lv.", priceAfterDiscount, discount);

    }
}

import java.util.Scanner;

public class FoodDelivery_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double chickenMenu = 10.35;
        Double fishMenu = 12.40;
        Double vegiMenu = 8.15;

        double delivery = 2.50;

        Integer totalChickenMenu = Integer.parseInt(scanner.nextLine());
        Integer totalFishMenu = Integer.parseInt(scanner.nextLine());
        Integer totalVegiMenu = Integer.parseInt(scanner.nextLine());

        double totalMenuPrice = chickenMenu * totalChickenMenu
                + fishMenu * totalFishMenu
                + vegiMenu * totalVegiMenu;

        double desertPrice = totalMenuPrice * 0.2;
        Double total = totalMenuPrice + desertPrice + delivery;

        System.out.println(total);

    }
}

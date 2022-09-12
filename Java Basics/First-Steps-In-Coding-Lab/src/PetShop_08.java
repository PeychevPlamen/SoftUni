import java.util.Scanner;

public class PetShop_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Double dogFoodPrice = 2.50;
        Double catFoodPrice = 4.0;

        Integer dogCountFood = Integer.parseInt(scanner.nextLine());
        Integer catCountFood = Integer.parseInt(scanner.nextLine());

        Double finalDogPrice = dogFoodPrice * dogCountFood;
        Double finalCatPrice = catFoodPrice * catCountFood;
        Double finalPrice = finalCatPrice + finalDogPrice;

        System.out.printf("%.1f lv.", finalPrice);
    }
}

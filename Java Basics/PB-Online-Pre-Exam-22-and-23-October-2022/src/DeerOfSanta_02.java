import java.util.Scanner;

public class DeerOfSanta_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int daysMissing = Integer.parseInt(scanner.nextLine());
        int foodInKgLeft = Integer.parseInt(scanner.nextLine());
        double firstDeerFood = Double.parseDouble(scanner.nextLine());
        double secondDeerFood = Double.parseDouble(scanner.nextLine());
        double thirdDeerFood = Double.parseDouble(scanner.nextLine());

        double totalFood = daysMissing * firstDeerFood + daysMissing * secondDeerFood + daysMissing * thirdDeerFood;

        if (totalFood > foodInKgLeft){
            double foodNeeded = Math.ceil(totalFood - foodInKgLeft);
            System.out.printf("%.0f more kilos of food are needed.", foodNeeded);
        } else {
            double foodLeft = Math.floor(foodInKgLeft - totalFood);
            System.out.printf("%.0f kilos of food left.", foodLeft);
        }
    }
}

import java.util.Scanner;

public class SummerOutfit_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int temp = Integer.parseInt(scanner.nextLine());
        String partOfDay = scanner.nextLine();
        String outfit = "";
        String shoes = "";

        if (temp >= 10 && temp <= 18) {
            switch (partOfDay) {
                case "Morning":
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                    break;
                case "Afternoon":
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
            }
        } else if (temp > 18 && temp <= 24) {
            switch (partOfDay) {
                case "Morning":
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
                case "Afternoon":
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    break;
            }
        } else if (temp >= 25) {
            switch (partOfDay) {
                case "Morning":
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                    break;
                case "Afternoon":
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                    break;
                case "Evening":
                    outfit = "Shirt";
                    shoes = "Moccasins";
                    break;
            }
        }
        System.out.printf("It's %d degrees, get your %s and %s.", temp, outfit, shoes);
    }
}

import java.util.Scanner;

public class BasketballEquipment_08 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int price = Integer.parseInt(scanner.nextLine());

        //•	Баскетболни кецове – цената им е 40% по-малка от таксата за една година
        //•	Баскетболен екип – цената му е 20% по-евтина от тази на кецовете
        //•	Баскетболна топка – цената ѝ е 1 / 4 от цената на баскетболния екип
        //•	Баскетболни аксесоари – цената им е 1 / 5 от цената на баскетболната топка
        double sneakers = price * 0.6;
        double jersey = sneakers * 0.8;
        double ball = jersey * 0.25;
        Double accessories = ball * 0.2;

        Double total = price + sneakers + jersey + ball + accessories;

        System.out.println(total);

    }
}

import java.util.Scanner;

public class Spaceship_02 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double spaceShipWidth = Double.parseDouble(scanner.nextLine());
        double spaceShipLength = Double.parseDouble(scanner.nextLine());
        double spaceShipHeight = Double.parseDouble(scanner.nextLine());
        double averageAstronautTall = Double.parseDouble(scanner.nextLine());

        double spaceShipValue = spaceShipWidth * spaceShipLength * spaceShipHeight;
        double oneRoomValue = (averageAstronautTall + 0.40) * 2 * 2;

        double totalRoomSpace = Math.floor(spaceShipValue / oneRoomValue);

        if (totalRoomSpace >= 3 && totalRoomSpace <= 10){
            System.out.printf("The spacecraft holds %.0f astronauts.", totalRoomSpace);
        } else if (totalRoomSpace < 3) {
            System.out.print("The spacecraft is too small.");
        } else {
            System.out.print("The spacecraft is too big.");
        }

    }
}

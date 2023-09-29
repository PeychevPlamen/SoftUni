import java.util.LinkedHashSet;
import java.util.Scanner;
import java.util.Set;

public class ParkingLot_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        Set<String> numbers =new LinkedHashSet<>();

        while (!input.equals("END")) {

            String[] tokens = input.split(", ");
            String direction = tokens[0];
            String carNumber = tokens[1];

            if (direction.equals("IN")) {
                numbers.add(carNumber);
            } else {
                numbers.remove(carNumber);
            }

            input = scanner.nextLine();
        }

        if (numbers.isEmpty()) {
            System.out.println("Parking Lot is Empty");
        } else {
            for (String car : numbers) {
                System.out.println(car);
            }
        }
    }
}

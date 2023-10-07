package SpeedRacing_03;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Map<String, Car> cars = new LinkedHashMap<>();

        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split("\\s+");
            String model = input[0];
            double fuelAmount = Double.parseDouble(input[1]);
            double fuelNeededPerKm = Double.parseDouble(input[2]);

            Car car = new Car(model, fuelAmount, fuelNeededPerKm);
            cars.put(model, car);
        }

        String cmd = scanner.nextLine();

        while (!cmd.equals("End")){
            String[] tokens = cmd.split("\\s+");
            String model = tokens[1];
            int amountOfKm = Integer.parseInt(tokens[2]);

            Car carToDrive = cars.get(model);

            if (!carToDrive.drive(amountOfKm)){
                System.out.println("Insufficient fuel for the drive");
            }

            cmd = scanner.nextLine();
        }

        for (Car car : cars.values()){
            System.out.println(car.toString());
        }
    }
}

package vehicles;

import java.util.*;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("\\s+");
        VehicleInterface vehicleCar = new Car(Double.parseDouble(input[1]),
                Double.parseDouble(input[2]),
                Double.parseDouble(input[3]));

        input = scanner.nextLine().split("\\s+");
        VehicleInterface vehicleTruck = new Truck(Double.parseDouble(input[1]),
                Double.parseDouble(input[2]),
                Double.parseDouble(input[3]));

        input = scanner.nextLine().split("\\s+");
        VehicleInterface vehicleBus = new Bus(Double.parseDouble(input[1]),
                Double.parseDouble(input[2]),
                Double.parseDouble(input[3]));

        Map<String, VehicleInterface> vehicleMap = new LinkedHashMap<>();
        vehicleMap.put("Car", vehicleCar);
        vehicleMap.put("Truck", vehicleTruck);
        vehicleMap.put("Bus", vehicleBus);

        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n; i++) {
            input = scanner.nextLine().split("\\s+");
            VehicleInterface vehicle = vehicleMap.get(input[1]);
            double param = Double.parseDouble(input[2]);

            try {
                if (input[0].equals("Drive")) {
                    vehicle.setEmpty(false);
                    vehicle.turnOnOfAc(vehicle.isEmpty());
                    System.out.println(vehicle.drive(param));

                } else if (input[0].equals("Refuel")) {
                    vehicle.refuel(param);
                } else if (input[0].equals("DriveEmpty")) {
                    vehicle.setEmpty(true);
                    vehicle.turnOnOfAc(vehicle.isEmpty());
                    System.out.println(vehicle.drive(param));
                }
            } catch (IllegalArgumentException e) {
                System.out.println(e.getMessage());
            }
        }

        vehicleMap.values().forEach(System.out::println);
    }
}

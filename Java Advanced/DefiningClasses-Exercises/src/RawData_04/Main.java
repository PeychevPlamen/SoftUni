package RawData_04;

import java.util.*;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        Map<String, List<Car>> carsByCargoType = new HashMap<>();

        for (int i = 0; i < n; i++) {
            String[] tokens = scanner.nextLine().split("\\s+");

            String model = tokens[0];
            int engineSpeed = Integer.parseInt(tokens[1]);
            int enginePower = Integer.parseInt(tokens[2]);
            int cargoWeight = Integer.parseInt(tokens[3]);
            String cargoType = tokens[4];

            Engine engine = new Engine(engineSpeed, enginePower);
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            List<Tire> tires = new ArrayList<>();
            for (int tireItems = 5; tireItems <= 12; tireItems+=2) {
                double tirePressure = Double.parseDouble(tokens[tireItems]);
                int tireAge = Integer.parseInt(tokens[tireItems + 1]);
                Tire tire = new Tire(tirePressure, tireAge);
                tires.add(tire);
            }
            Car car = new Car(model, engine, cargo, tires);
            carsByCargoType.putIfAbsent(cargoType, new ArrayList<>());
            carsByCargoType.get(cargoType).add(car);
        }
        String cmd = scanner.nextLine();

        carsByCargoType.get(cmd).forEach(car->car.extract(cmd));
    }
}

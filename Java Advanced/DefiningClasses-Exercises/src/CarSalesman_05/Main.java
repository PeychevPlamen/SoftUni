package CarSalesman_05;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        List<Engine> engines = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] enginesInput = scanner.nextLine().split("\\s+");
            String engineModel = enginesInput[0];
            int enginePower = Integer.parseInt(enginesInput[1]);
            //optional
            int engineDisplacement = 0;
            String engineEfficiency = null;

            if (enginesInput.length == 3) {
                if (Character.isDigit(enginesInput[2].charAt(0))) {
                    engineDisplacement = Integer.parseInt(enginesInput[2]);
                } else {
                    engineEfficiency = enginesInput[2];
                }
            } else if (enginesInput.length == 4) {
                engineDisplacement = Integer.parseInt(enginesInput[2]);
                engineEfficiency = enginesInput[3];
            }

            Engine engine = new Engine(engineModel, enginePower, engineDisplacement, engineEfficiency);
            engines.add(engine);
        }

        int m = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < m; i++) {
            String[] carInput = scanner.nextLine().split("\\s+");
            String carModel = carInput[0];
            String engineModel = carInput[1];
            //optional
            int weight = 0;
            String color = null;

            if (carInput.length == 3) {
                if (Character.isDigit(carInput[2].charAt(0))) {
                    weight = Integer.parseInt(carInput[2]);
                } else {
                    color = carInput[2];
                }
            } else if (carInput.length == 4) {
                weight = Integer.parseInt(carInput[2]);
                color = carInput[3];
            }

            Engine engine = null;
            for (Engine e : engines) {
                if (engineModel.equals(e.getModel())) {
                    engine = e;
                    break;
                }
            }

            Car car = new Car(carModel, engine, weight, color);
            System.out.print(car.toString());
        }
    }
}

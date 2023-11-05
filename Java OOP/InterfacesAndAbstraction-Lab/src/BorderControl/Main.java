package BorderControl;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        List<Identifiable> identifiableList = new ArrayList<>();

        while (!input.equals("End")) {

            String[] line = input.split("\\s+");
            Identifiable identifiable;

            if (line.length == 2) {
                String model = line[0];
                String id = line[1];
                identifiable = new Robot(model, id);

            } else {
                String name = line[0];
                int age = Integer.parseInt(line[1]);
                String id = line[2];

                identifiable = new Citizen(name, age, id);
            }

            identifiableList.add(identifiable);
            input = scanner.nextLine();
        }

        String num = scanner.nextLine();

        for (Identifiable i : identifiableList) {
            if (i.getId().endsWith(num)) {
                System.out.println(i.getId());
            }
        }

        //   identifiableList.stream()
        //                .filter(i -> i.getId().endsWith(num))
        //                .forEach(i -> System.out.println(i.getId()));
    }
}

package birthday_celebration;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();

        List<Birthable> birthableList = new ArrayList<>();

        while (!input.equals("End")) {

            Birthable birthable;

            String[] line = input.split("\\s+");
            String type = line[0];
            String name = line[1];

            if (type.equals("Citizen")) {
                int age = Integer.parseInt(line[2]);
                String id = line[3];
                String birthDate = line[4];
                birthable = new Citizen(name, age, id, birthDate);
                birthableList.add(birthable);
            } else if (type.equals("Pet")) {
                String birthDate = line[2];
                birthable = new Pet(name, birthDate);
                birthableList.add(birthable);
            }

            input = scanner.nextLine();

        }
        String num = scanner.nextLine();

        birthableList.stream()
                .filter(b -> b.getBirthDate().endsWith(num))
                .forEach(b -> System.out.println(b.getBirthDate()));


    }
}

package food_shortage;

import java.util.*;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        Map<String, Buyer> buyerMap = new HashMap<>();


        for (int i = 0; i < n; i++) {
            Buyer buyer;
            String[] input = scanner.nextLine().split("\\s+");
            String name = input[0];
            int age = Integer.parseInt(input[1]);

            if (input.length == 4) {
                String id = input[2];
                String birthDate = input[3];
                buyer = new Citizen(name, age, id, birthDate);

            } else {
                String group = input[2];
                buyer = new Rebel(name, age, group);

            }
            buyerMap.put(name, buyer);
        }

        String name = scanner.nextLine();

        while (!name.equals("End")) {
            Buyer buyer = buyerMap.get(name);
            if (buyer != null) {
                buyer.buyFood();
            }
            name = scanner.nextLine();
        }

        int boughtFood = buyerMap.values()
                .stream()
                .mapToInt(Buyer::getFood)
                .sum();

        System.out.println(boughtFood);
    }
}

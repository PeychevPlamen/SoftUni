
package greedyTimes;

import java.util.Collection;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        long input = Long.parseLong(scanner.nextLine());
        String[] itemsAndQuantity = scanner.nextLine().split("\\s+");

        var bag = new LinkedHashMap<String, LinkedHashMap<String, Long>>();
        long gold = 0;
        long stones = 0;
        long money = 0;

        for (int i = 0; i < itemsAndQuantity.length; i += 2) {
            String name = itemsAndQuantity[i];
            long count = Long.parseLong(itemsAndQuantity[i + 1]);

            String items = "";

            if (name.length() == 3) {
                items = "Cash";
            } else if (name.toLowerCase().endsWith("gem")) {
                items = "Gem";
            } else if (name.toLowerCase().equals("gold")) {
                items = "Gold";
            }

            if (items.equals("")) {
                continue;
            } else if (input < bag.values().stream().map(Map::values).flatMap(Collection::stream).mapToLong(e -> e).sum() + count) {
                continue;
            }

            switch (items) {
                case "Gem":
                    if (!bag.containsKey(items)) {
                        if (bag.containsKey("Gold")) {
                            if (count > bag.get("Gold").values().stream().mapToLong(e -> e).sum()) {
                                continue;
                            }
                        } else {
                            continue;
                        }
                    } else if (bag.get(items).values().stream().mapToLong(e -> e).sum() + count > bag.get("Gold").values().stream().mapToLong(e -> e).sum()) {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!bag.containsKey(items)) {
                        if (bag.containsKey("Gem")) {
                            if (count > bag.get("Gold").values().stream().mapToLong(e -> e).sum()) {
                                continue;
                            }
                        } else {
                            continue;
                        }
                    } else if (bag.get(items).values().stream().mapToLong(e -> e).sum() + count > bag.get("Gem").values().stream().mapToLong(e -> e).sum()) {
                        continue;
                    }
                    break;
            }

            if (!bag.containsKey(items)) {
                bag.put((items), new LinkedHashMap<String, Long>());
            }

            if (!bag.get(items).containsKey(name)) {
                bag.get(items).put(name, 0L);
            }


            bag.get(items).put(name, bag.get(items).get(name) + count);
            if (items.equals("Gold")) {
                gold += count;
            } else if (items.equals("Gem")) {
                stones += count;
            } else if (items.equals("Cash")) {
                money += count;
            }
        }

        for (var x : bag.entrySet()) {
            Long sumValues = x.getValue().values().stream().mapToLong(l -> l).sum();

            System.out.println(String.format("<%s> $%s", x.getKey(), sumValues));

            x.getValue().entrySet().stream().sorted((e1, e2) -> e2.getKey().compareTo(e1.getKey())).forEach(i -> System.out.println("##" + i.getKey() + " - " + i.getValue()));

        }
    }
}
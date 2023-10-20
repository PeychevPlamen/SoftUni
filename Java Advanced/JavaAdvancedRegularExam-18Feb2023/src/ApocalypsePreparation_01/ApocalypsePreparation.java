package ApocalypsePreparation_01;

import java.util.*;
import java.util.stream.Collectors;

public class ApocalypsePreparation {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Integer> textilesQueue = new ArrayDeque<>();
        Deque<Integer> medicamentStack = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(textilesQueue::offer);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(medicamentStack::push);

        Map<String, Integer> items = new HashMap<>();
        items.put("Patch", 0);
        items.put("Bandage", 0);
        items.put("MedKit", 0);

        while (!textilesQueue.isEmpty() && !medicamentStack.isEmpty()) {
            int sum = textilesQueue.peek() + medicamentStack.peek();
            if (sum == 30) {
                int currentNumPatch = items.get("Patch");
                items.put("Patch", currentNumPatch + 1);
                textilesQueue.poll();
                medicamentStack.pop();
            } else if (sum == 40) {
                int currentNumPatch = items.get("Bandage");
                items.put("Bandage", currentNumPatch + 1);
                textilesQueue.poll();
                medicamentStack.pop();
            } else if (sum == 100) {
                int currentNumPatch = items.get("MedKit");
                items.put("MedKit", currentNumPatch + 1);
                textilesQueue.poll();
                medicamentStack.pop();
            } else if (sum > 100) {
                int currentNumPatch = items.get("MedKit");
                items.put("MedKit", currentNumPatch + 1);
                textilesQueue.poll();
                medicamentStack.pop();
                medicamentStack.push(medicamentStack.pop() + (sum - 100));
            } else {
                textilesQueue.poll();
                medicamentStack.push(medicamentStack.pop() + 10);
            }
        }

        if (textilesQueue.isEmpty() && medicamentStack.isEmpty()) {
            System.out.println("Textiles and medicaments are both empty.");
        } else if (textilesQueue.isEmpty()) {
            System.out.println("Textiles are empty.");
        } else if (medicamentStack.isEmpty()) {
            System.out.println("Medicaments are empty.");
        }
        // !!!!!!!! sorting map by TWO parameters and print

        List<Map.Entry<String, Integer>> orderedItems =
                new ArrayList<>(items.entrySet());
        Collections.sort(orderedItems,
                Comparator.comparing(Map.Entry<String, Integer>::getValue).reversed().
                        thenComparing(Map.Entry<String, Integer>::getKey));

        // print only if there is a value
        for (Map.Entry<String, Integer> item : orderedItems) {
            if (item.getValue() != 0) {
                System.out.println(item.getKey() + " - " + item.getValue());
            }
        }

        // !!!!!!!!!!!!

        if (!medicamentStack.isEmpty()) {
            System.out.println("Medicaments left: " + medicamentStack.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
        if (!textilesQueue.isEmpty()) {
            System.out.println("Textiles left: " + textilesQueue.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }

    }
}

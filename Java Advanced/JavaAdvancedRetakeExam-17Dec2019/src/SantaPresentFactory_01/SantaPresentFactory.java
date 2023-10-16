package SantaPresentFactory_01;

import java.util.*;
import java.util.stream.Collectors;

public class SantaPresentFactory {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Integer> materialsStack = new ArrayDeque<>();
        Deque<Integer> magicLevelQueue = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(materialsStack::push);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(magicLevelQueue::offer);
        TreeMap<String, List<Integer> > gifts = new TreeMap<>(){};

        while (!materialsStack.isEmpty() && !magicLevelQueue.isEmpty()) {
            if (materialsStack.peek() == 0) {
                materialsStack.pop();
                continue;
            }
            if (magicLevelQueue.peek() == 0) {
                magicLevelQueue.poll();
                continue;
            }
            if (materialsStack.peek() * magicLevelQueue.peek() < 0) {
                int sum = materialsStack.pop() + magicLevelQueue.poll();
                materialsStack.push(sum);
                continue;
            }
            if (materialsStack.peek() * magicLevelQueue.peek() == 150) {
                if (!gifts.containsKey("Doll")){
                    gifts.put("Doll",new ArrayList<>());
                    gifts.get("Doll").add(1);
                }else {
                    gifts.get("Doll").add(1);
                }
                //dollCount++;
            } else if (materialsStack.peek() * magicLevelQueue.peek() == 250) {
                if (!gifts.containsKey("Wooden train")){
                    gifts.put("Wooden train", new ArrayList<>());
                    gifts.get("Wooden train").add(1);
                }else {
                    gifts.get("Wooden train").add(1);
                }
                //woodenTrainCount++;
            } else if (materialsStack.peek() * magicLevelQueue.peek() == 300) {
                if (!gifts.containsKey("Teddy bear")){
                    gifts.put("Teddy bear", new ArrayList<>());
                    gifts.get("Teddy bear").add(1);
                }else {
                    gifts.get("Teddy bear").add(1);
                }
                //teddyBearCount++;
            } else if (materialsStack.peek() * magicLevelQueue.peek() == 400) {
                if (!gifts.containsKey("Bicycle")){
                    gifts.put("Bicycle",new ArrayList<>());
                    gifts.get("Bicycle").add(1);
                }else {
                    gifts.get("Bicycle").add(1);
                }
                //bicycleCount++;
            } else {
                magicLevelQueue.poll();
                materialsStack.push(materialsStack.pop() + 15);
                continue;
            }
            materialsStack.pop();
            magicLevelQueue.poll();
        }
        if (gifts.containsKey("Doll") && gifts.containsKey("Wooden train") ||
        gifts.containsKey("Bicycle") && gifts.containsKey("Teddy bear")){
            System.out.println("The presents are crafted! Merry Christmas!");
        } else {
            System.out.println("No presents this Christmas!");
        }
        if (!materialsStack.isEmpty()){
            System.out.println("Materials left: " + materialsStack.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
        if (!magicLevelQueue.isEmpty()){
            System.out.println("Magic left: " + magicLevelQueue.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
        gifts.forEach((key, value) -> {
            int count = gifts.get(key).size();
            System.out.printf("%s: %d\n", key, count);
        });
    }
}

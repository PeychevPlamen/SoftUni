package OffroadChallenge_01;

import java.util.*;

public class OffroadChallenge {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        Deque<Integer> initialFuelStack = new ArrayDeque<>();
        Deque<Integer> consumptionQueue = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(initialFuelStack::push);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(consumptionQueue::offer);

        Deque<Integer> fuelNeededQueue = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(fuelNeededQueue::offer);

        int count = 0;

        while (!fuelNeededQueue.isEmpty() && !initialFuelStack.isEmpty() && !consumptionQueue.isEmpty()) {
            int fuel = initialFuelStack.peek();
            int consumption = consumptionQueue.peek();
            int result = fuel - consumption;
            int temp = fuelNeededQueue.peek();
            if (result >= temp) {
                initialFuelStack.pop();
                consumptionQueue.poll();
                fuelNeededQueue.poll();
                count++;
            } else {
                break;
            }
        }

        if (count == 0) {
            System.out.println("John failed to reach the top.");
            System.out.println("John didn't reach any altitude.");
        } else if (consumptionQueue.isEmpty()) {
            for (int i = 1; i <= count; i++) {

                System.out.printf("John has reached: Altitude %d\n", i);

            }
            System.out.println("John has reached all the altitudes and managed to reach the top!");
        } else if (!fuelNeededQueue.isEmpty()) {
            for (int i = 1; i <= count; i++) {
                System.out.printf("John has reached: Altitude %d\n", i);
            }
            System.out.printf("John did not reach: Altitude %d\n", count + 1);
            if (count != 4){
                StringBuilder sb = new StringBuilder();
                sb.append("John failed to reach the top.").append(System.lineSeparator());
                sb.append("Reached altitudes: ");
                for (int i = 1; i <= count; i++) {
                    if (count == i) {
                        sb.append("Altitude ").append(i);
                    } else {
                        sb.append("Altitude ").append(i).append(", ");
                    }
                }
                System.out.println(sb.toString());
            }
        }
    }
}
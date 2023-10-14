package EnergyDrinks_01;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

public class EnergyDrinks_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        ArrayDeque<Integer> caffeineStack = new ArrayDeque<>();
        ArrayDeque<Integer> energyDrinkQueue = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split(", "))
                .mapToInt(Integer::parseInt)
                .forEach(caffeineStack::push);

        Arrays.stream(scanner.nextLine().split(", "))
                .mapToInt(Integer::parseInt)
                .forEach(energyDrinkQueue::offer);

        int maxCaffeine = 300;
        int stamatCaffeine = 0;

        while (!caffeineStack.isEmpty() && !energyDrinkQueue.isEmpty()) {
            int caffeine = caffeineStack.peek();
            int drink = energyDrinkQueue.peek();
            int multiply = caffeine * drink;

            if (multiply <= maxCaffeine - stamatCaffeine) {
                stamatCaffeine += multiply;
                caffeineStack.pop();
                energyDrinkQueue.poll();
            } else {
                caffeineStack.pop();
                energyDrinkQueue.offer(energyDrinkQueue.poll());
                if (stamatCaffeine >= 30)
                    stamatCaffeine -= 30;
            }
        }

        if (!energyDrinkQueue.isEmpty()) {
            System.out.println("Drinks left: " + energyDrinkQueue.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        } else {
            System.out.println("At least Stamat wasn't exceeding the maximum caffeine.");
        }

        System.out.printf("Stamat is going to sleep with %s mg caffeine.", stamatCaffeine);
    }
}

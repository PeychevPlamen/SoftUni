package ItsChocolateTime_01;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class ItsChocolateTime {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Double> milkQueue = new ArrayDeque<>();
        Deque<Double> cacaoStack = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToDouble(Double::parseDouble)
                .forEach(milkQueue::offer);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToDouble(Double::parseDouble)
                .forEach(cacaoStack::push);

        int bakingChocolate = 0;
        int darkChocolate = 0;
        int milkChocolate = 0;

        while (!milkQueue.isEmpty() && !cacaoStack.isEmpty()) {
            double cacaoPercentage = (cacaoStack.peek() / (cacaoStack.peek() + milkQueue.peek()))*100;
            if (cacaoPercentage == 30) {
                milkChocolate++;
                milkQueue.poll();
            } else if (cacaoPercentage == 50) {
                darkChocolate++;
                milkQueue.poll();
            } else if (cacaoPercentage == 100) {
                bakingChocolate++;
                milkQueue.poll();
            } else {
                milkQueue.offer(milkQueue.poll() + 10);
            }
            cacaoStack.pop();
        }
        if (bakingChocolate > 0 && darkChocolate > 0 && milkChocolate > 0){
            System.out.println("It’s a Chocolate Time. All chocolate types are prepared.");
        } else {
            System.out.println("Sorry, but you didn't succeed to prepare all types of chocolates.");
        }
        if (bakingChocolate > 0){
            System.out.printf("# Baking Chocolate --> %d%n", bakingChocolate);
        }
        if (darkChocolate > 0){
            System.out.printf("# Dark Chocolate --> %d%n", darkChocolate);
        }
        if (milkChocolate > 0){
            System.out.printf("# Milk Chocolate --> %d%n", milkChocolate);
        }

    }
}

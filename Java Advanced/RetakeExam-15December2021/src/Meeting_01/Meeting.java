package Meeting_01;

import java.util.*;
import java.util.stream.Collectors;

public class Meeting {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Integer> stackMales = new ArrayDeque<>();
        Deque<Integer> queueFemales = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(stackMales::push);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(queueFemales::offer);

        int matches = 0;

        while (!stackMales.isEmpty() && !queueFemales.isEmpty()) {

            int male = stackMales.peek();
            if (male <= 0) {
                stackMales.pop();
                continue;
            } else if (male % 25 == 0) {
                stackMales.pop();
                stackMales.pop();
                continue;
            }

            int female = queueFemales.peek();
            if (female <= 0) {
                queueFemales.poll();
                continue;
            } else if (female % 25 == 0) {
                queueFemales.poll();
                queueFemales.poll();
                continue;
            }

            if (male == female){
                matches++;
                stackMales.pop();
                queueFemales.poll();
            } else {
                queueFemales.poll();
                stackMales.push(stackMales.pop() - 2);
            }
        }

        System.out.printf("Matches: %s\n", matches);

        if (stackMales.isEmpty()) {
            System.out.println("Males left: none");
        } else {
            System.out.println("Males left: " + stackMales.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
        if (queueFemales.isEmpty()) {
            System.out.println("Females left: none");
        } else {
            System.out.println("Females left: " + queueFemales.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
    }
}

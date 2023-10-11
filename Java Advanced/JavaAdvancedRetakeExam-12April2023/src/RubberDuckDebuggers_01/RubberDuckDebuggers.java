package RubberDuckDebuggers_01;

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Scanner;

public class RubberDuckDebuggers {
    public static int darthVaderDucky = 0;
    public static int thorDucky = 0;
    public static int bigBlueRubberDucky = 0;
    public static int smallYellowRubberDucky = 0;
    public static ArrayDeque<Integer> timeQueue = new ArrayDeque<>();
    public static ArrayDeque<Integer> tasksStack = new ArrayDeque<>();

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(timeQueue::offer);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(tasksStack::push);


        while (!timeQueue.isEmpty() && !tasksStack.isEmpty()) {

            int multiplyNum = timeQueue.peek() * tasksStack.peek();

            duckCheck(multiplyNum);
        }

        System.out.println("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
        System.out.println("Darth Vader Ducky: " + darthVaderDucky);
        System.out.println("Thor Ducky: " + thorDucky);
        System.out.println("Big Blue Rubber Ducky: " + bigBlueRubberDucky);
        System.out.println("Small Yellow Rubber Ducky: " + smallYellowRubberDucky);
    }

    private static void duckCheck(int num) {
        if (num >= 0 && num <= 60) {
            darthVaderDucky++;
            timeQueue.poll();
            tasksStack.pop();
        } else if (num > 60 && num <= 120) {
            thorDucky++;
            timeQueue.poll();
            tasksStack.pop();
        } else if (num > 120 && num <= 180) {
            bigBlueRubberDucky++;
            timeQueue.poll();
            tasksStack.pop();
        } else if (num > 180 && num <= 240) {
            smallYellowRubberDucky++;
            timeQueue.poll();
            tasksStack.pop();
        } else {
            int tempNumTask = tasksStack.pop() - 2;
            tasksStack.push(tempNumTask);
            int tempNumQueue = timeQueue.pop();
            timeQueue.offer(tempNumQueue);
        }

    }
}

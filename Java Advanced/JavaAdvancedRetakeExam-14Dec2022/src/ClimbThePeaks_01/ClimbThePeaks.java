package ClimbThePeaks_01;

import java.util.*;
import java.util.stream.Collectors;

public class ClimbThePeaks {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<Integer> foodStack = new ArrayDeque<>();
        Deque<Integer> staminaQueue = new ArrayDeque<>();

        Arrays.stream(scanner.nextLine().split(",\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(foodStack::push);

        Arrays.stream(scanner.nextLine().split(",\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(staminaQueue::offer);

        ArrayDeque<String> peaks = new ArrayDeque<>(Arrays.asList("Vihren", "Kutelo", "Banski Suhodol", "Polezhan", "Kamenitza"));
        HashMap<String, Integer> peaksToClimb = new LinkedHashMap<>();
        peaksToClimb.put("Vihren", 80);
        peaksToClimb.put("Kutelo", 90);
        peaksToClimb.put("Banski Suhodol", 100);
        peaksToClimb.put("Polezhan", 60);
        peaksToClimb.put("Kamenitza", 70);

        List<String> conqueredPeaks = new ArrayList<>();

        while (!peaksToClimb.isEmpty() && !foodStack.isEmpty() && !staminaQueue.isEmpty()) {
            String currentPeakName = peaks.getFirst();
            if (foodStack.peek() + staminaQueue.peek() >= peaksToClimb.get(currentPeakName)) {
                conqueredPeaks.add(currentPeakName);
                staminaQueue.poll();
                foodStack.pop();
                peaksToClimb.remove(currentPeakName);
                peaks.remove(currentPeakName);
            } else {
                foodStack.pop();
                staminaQueue.poll();
            }
        }
        if (peaksToClimb.isEmpty()) {
            System.out.println("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        } else {
            System.out.println("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
        }

        if (!conqueredPeaks.isEmpty()) {
            System.out.println("Conquered peaks:");
            System.out.println(conqueredPeaks.stream()
                    .map(String::valueOf)
                    .collect(Collectors.joining(System.lineSeparator())));
        }
    }
}


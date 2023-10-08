package TempleOfDoom_01;

import java.util.*;
import java.util.stream.Collectors;

public class TempleOfDoom {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        ArrayDeque<Integer> queueTools = new ArrayDeque<>();
        ArrayDeque<Integer> stackSubstances = new ArrayDeque<>();

        List<Integer> challengesList = new ArrayList<>();

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(queueTools::offer);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(stackSubstances::push);

        Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .forEach(challengesList::add);

        while (true) {
            int toolsNum = queueTools.peek();
            int substancesNum = stackSubstances.peek();
            int multiply = toolsNum * substancesNum;

            if (challengesList.contains(multiply)) {
                challengesList.remove(Integer.valueOf(multiply));
                queueTools.poll();
                stackSubstances.pop();

                if (challengesList.isEmpty()) {
                    System.out.println("Harry found an ostracon, which is dated to the 6th century BCE.");
                    break;
                }
            } else {
                queueTools.poll();
                queueTools.offer(toolsNum + 1);
                stackSubstances.pop();
                if (substancesNum - 1 > 0) {
                    stackSubstances.push(substancesNum - 1);
                }
            }

            if (queueTools.isEmpty() || stackSubstances.isEmpty()){
                System.out.println("Harry is lost in the temple. Oblivion awaits him.");
                break;
            }
            if (challengesList.isEmpty()){
                System.out.println("Harry found an ostracon, which is dated to the 6th century BCE.");
                break;
            }
        }

        if (!queueTools.isEmpty()){
            System.out.println("Tools: " + queueTools.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));

//            StringBuilder sb = new StringBuilder();
//            int n = queueTools.size();
//            for (int i = 0; i < n; i++) {
//                if (i == n - 1){
//                    sb.append(queueTools.poll());
//                } else {
//                    sb.append(queueTools.poll()).append(", ");
//                }
//            }
//            System.out.println("Tools: " + sb);
        }
        if (!stackSubstances.isEmpty()){
            System.out.println("Substances: " + stackSubstances.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
        if (!challengesList.isEmpty()){
            System.out.println("Challenges: " + challengesList.stream()
                    .map(Object::toString)
                    .collect(Collectors.joining(", ")));
        }
    }
}

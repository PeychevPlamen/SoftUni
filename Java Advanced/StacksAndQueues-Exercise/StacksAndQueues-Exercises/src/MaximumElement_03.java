import java.util.*;

public class MaximumElement_03 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int cmd = Integer.parseInt(scanner.nextLine());
        Deque<Integer> stack = new ArrayDeque<>();

        for (int i = 0; i < cmd; i++) {

            int[] input = Arrays.stream(scanner.nextLine().split("\\s+"))
                    .mapToInt(Integer::parseInt)
                    .toArray();

            if (input.length > 1) {
                stack.push(input[1]);
            } else if (input[0] == 2) {
                stack.pop();
            } else {
                System.out.println(Collections.max(stack));
            }
        }
    }
}

import java.util.ArrayDeque;
import java.util.Arrays;
import java.util.Deque;
import java.util.Scanner;

public class ReverseNumberWithAStack_01 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] nums = scanner.nextLine().split("\\s+");

        Deque<String> stack = new ArrayDeque<>();

//        // Add elements to the stack
//        Arrays.stream(scanner.nextLine().split("\\s+"))
//                .map(Integer::parseInt)
//                .forEach(stack::push);

        for (int i = 0; i < nums.length; i++) {
            stack.push(nums[i]);
        }
        while (!stack.isEmpty()) {
            System.out.print(stack.pop() + " ");
        }
    }
}

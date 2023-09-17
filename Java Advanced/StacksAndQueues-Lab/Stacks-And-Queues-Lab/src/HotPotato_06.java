import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class HotPotato_06 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Deque<String> queue = new ArrayDeque<>();

        String[] names = scanner.nextLine().split("\\s+");
        int count = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < names.length; i++) {
            queue.offer(names[i]);
        }

        while (queue.size() > 1) {
            for (int i = 1; i < count; i++) {

                queue.offer(queue.poll());

            }
            System.out.println("Removed " + queue.poll());
        }
        System.out.println("Last is " + queue.poll());
    }
}

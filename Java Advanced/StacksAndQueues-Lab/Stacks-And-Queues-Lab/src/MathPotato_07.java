import java.util.Collections;
import java.util.PriorityQueue;
import java.util.Scanner;

public class MathPotato_07 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] names = scanner.nextLine().split("\\s+");
        int n = Integer.parseInt(scanner.nextLine());

        PriorityQueue<String> children = new PriorityQueue<>();

        Collections.addAll(children, names);

        int counter = 1;

        while (children.size() > 1) {
            for (int i = 1; i < n; i++) {
                children.offer(children.poll());
            }
            if (isPrime(counter)) {
                System.out.println("Prime " + children.peek());
            } else {
                System.out.println("Removed " + children.poll());
            }
            counter++;
        }
        System.out.println("Last is " + children.poll());
    }

    private static boolean isPrime(int n) {

        // Corner case
        if (n <= 1)
            return false;

        // Check from 2 to n-1
        for (int i = 2; i < n; i++)
            if (n % i == 0)
                return false;

        return true;
    }

}


import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class BrowserHistoryUpgrade_08 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        Deque<String> browserHistory = new ArrayDeque<>();
        Deque<String> forwardHistory = new ArrayDeque<>();

        while (!input.equals("Home")) {
            if (input.equals("back")) {
                if (browserHistory.size() < 2) {
                    System.out.println("no previous URLs");
                } else {
                    forwardHistory.addFirst(browserHistory.peek());
                    browserHistory.pop();
                    System.out.println(browserHistory.peek());
                }
            } else if (input.equals("forward")) {
                if (forwardHistory.isEmpty()) {
                    System.out.println("no next URLs");
                } else {
                    System.out.println(forwardHistory.peek());
                    browserHistory.push(forwardHistory.pop());
                }
            } else {
                browserHistory.push(input);
                System.out.println(input);
                forwardHistory.clear();
            }
            input = scanner.nextLine();
        }
    }
}

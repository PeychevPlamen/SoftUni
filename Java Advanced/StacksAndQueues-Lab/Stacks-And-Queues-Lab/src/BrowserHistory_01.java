import java.util.ArrayDeque;
import java.util.Scanner;

public class BrowserHistory_01 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        ArrayDeque<String> browser = new ArrayDeque<>();
        String inputURL = scanner.nextLine();

        String currentURL = "";

        while (!inputURL.equals("Home")) {
            if (inputURL.equals("back")) {
                if (!browser.isEmpty()) {
                    currentURL = browser.pop();
                } else {
                    System.out.println("no previous URLs");
                    inputURL = scanner.nextLine();
                    continue;
                }
            } else {
                if (!currentURL.equals("")) {
                    browser.push(currentURL);
                }
                currentURL = inputURL;

            }
            System.out.println(currentURL);
            inputURL = scanner.nextLine();
        }
    }
}

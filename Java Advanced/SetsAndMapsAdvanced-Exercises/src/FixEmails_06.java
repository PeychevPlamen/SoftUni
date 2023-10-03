import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class FixEmails_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Map<String, String> namesAndEmails = new LinkedHashMap<>();

        String input = scanner.nextLine();

        while (!input.equals("stop")) {
            String name = input;
            String email = scanner.nextLine();

            if (!email.endsWith(".us") && !email.endsWith(".uk") && !email.endsWith(".com")) {
                namesAndEmails.put(name, email);
            }

            input = scanner.nextLine();
        }

        namesAndEmails.forEach((name, email) -> System.out.printf("%s -> %s\n", name, email));
    }
}

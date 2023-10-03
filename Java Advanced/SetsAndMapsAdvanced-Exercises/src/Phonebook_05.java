import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Phonebook_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        Map<String, String> contacts = new HashMap<>();

        String input = scanner.nextLine();

        while (!input.equals("search")) {

            String name = input.split("-")[0];
            String phone = input.split("-")[1];

            contacts.put(name, phone);

            input = scanner.nextLine();
        }
        input = scanner.nextLine();

        while (!input.equals("stop")) {

            String name = input;

            if (!contacts.containsKey(name)) {
                System.out.printf("Contact %s does not exist.\n", name);
            } else {
               System.out.printf("%s -> %s\n", name, contacts.get(name));
            }

            input = scanner.nextLine();
        }
    }
}

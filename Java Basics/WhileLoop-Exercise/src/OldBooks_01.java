import java.util.Scanner;

public class OldBooks_01 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String searchBook = scanner.nextLine();
        String input = scanner.nextLine();
        int count = 0;
        boolean foundIt = false;

        while (!input.equals("No More Books")) {

            if (searchBook.equals(input)) {
                foundIt = true;
                break;
            }
            count++;
            input = scanner.nextLine();
        }
        if (foundIt) {
            System.out.printf("You checked %d books and found it.", count);
        } else {
            System.out.println("The book you search is not here!");
            System.out.printf("You checked %d books.", count);
        }

    }
}

import java.util.Scanner;

public class Moving_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int widht = Integer.parseInt(scanner.nextLine());
        int length = Integer.parseInt(scanner.nextLine());
        int h = Integer.parseInt(scanner.nextLine());

        String input = scanner.nextLine();

        int totalSpace = widht * length * h;

        while (!input.equals("Done")) {
            int boxes = Integer.parseInt(input);

            totalSpace -= boxes;

            if (totalSpace <= 0) {
                break;
            }

            input = scanner.nextLine();
        }
        if (totalSpace > 0){
            System.out.printf("%d Cubic meters left.", totalSpace);
        } else {
            System.out.printf("No more free space! You need %d Cubic meters more.", Math.abs(totalSpace));
        }
    }
}

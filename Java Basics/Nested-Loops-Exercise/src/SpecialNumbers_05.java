import java.util.Scanner;

public class SpecialNumbers_05 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int num = Integer.parseInt(scanner.nextLine());

        for (int i = 1111; i <= 9999; i++) {

            String currNum = String.valueOf(i);
            boolean isMagic = true;

            for (int j = 0; j < currNum.length(); j++) {

                int n = Integer.parseInt(String.valueOf(currNum.charAt(j)));

                if (n == 0) {
                    isMagic = false;
                } else if (num % n != 0) {
                    isMagic = false;
                }
            }

            if (isMagic) {
                System.out.printf("%s ", currNum);
            }
        }
    }
}

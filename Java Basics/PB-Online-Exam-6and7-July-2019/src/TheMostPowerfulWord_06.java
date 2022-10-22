import java.util.Scanner;

public class TheMostPowerfulWord_06 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String theWord = "";
        String input = scanner.nextLine();

        int count = 0;

        while (!input.equals("End of words")) {

            int tempCount = 0;

            for (int i = 0; i < input.length(); i++) {

                tempCount += input.charAt(i);

            }
            char firstLetter = input.charAt(0);

            if (firstLetter == 'a'
                    || firstLetter == 'e'
                    || firstLetter == 'i'
                    || firstLetter == 'o'
                    || firstLetter == 'u'
                    || firstLetter == 'y'
                    || firstLetter == 'A'
                    || firstLetter == 'E'
                    || firstLetter == 'I'
                    || firstLetter == 'O'
                    || firstLetter == 'U'
                    || firstLetter == 'Y') {

                tempCount *= input.length();
            } else {
                tempCount = (int)(Math.round(count * 1.0 / input.length()));
            }
            if (tempCount > count) {
                theWord = input;
                count = tempCount;
            }

            input = scanner.nextLine();
        }

        System.out.printf("The most powerful word is %s - %d", theWord, count);
    }
}

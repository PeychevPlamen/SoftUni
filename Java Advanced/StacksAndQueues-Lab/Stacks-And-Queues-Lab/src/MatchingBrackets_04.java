import java.util.ArrayDeque;
import java.util.Scanner;

public class MatchingBrackets_04 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String input = scanner.nextLine();

        ArrayDeque<Integer> index = new ArrayDeque<>();

        for (int i = 0; i < input.length(); i++) {

            char currChar = input.charAt(i);

            if (currChar == '(') {
                index.push(i);
            } else if (currChar == ')') {
                int startIndex = index.pop();
                String output = input.substring(startIndex, i + 1);
                System.out.println(output);
            }
        }
    }
}

import javax.xml.transform.sax.TemplatesHandler;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class BalancedParentheses_05 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] input = scanner.nextLine().split("");

        String result = isBalanced(input) ? "YES" : "NO";

        System.out.println(result);
    }

    private static boolean isBalanced(String[] input) {

        Deque<String> openParenthesesStack = new ArrayDeque<>();

        for (int i = 0; i < input.length; i++) {
            String brace = input[i];
            String openBrace = "";
            switch (brace) {
                case "}":
                    if (openParenthesesStack.isEmpty()) {
                        return false;
                    }
                    openBrace = openParenthesesStack.pop();
                    if (!openBrace.equals("{")){
                        return false;
                    }
                    break;
                case "]":
                    if (openParenthesesStack.isEmpty()) {
                        return false;
                    }
                    openBrace = openParenthesesStack.pop();
                    if (!openBrace.equals("[")){
                        return false;
                    }
                    break;
                case ")":
                    if (openParenthesesStack.isEmpty()) {
                        return false;
                    }
                    openBrace = openParenthesesStack.pop();
                    if (!openBrace.equals("(")){
                        return false;
                    }
                    break;
                default:
                    openParenthesesStack.push(brace);
                    break;
            }

        }

        return true;
    }
}

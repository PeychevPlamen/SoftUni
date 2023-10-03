import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class CountSymbols_04 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        
        String text = scanner.nextLine();

        Map<Character, Integer> symbols = new TreeMap<>();

        for (int i = 0; i < text.length(); i++) {
            char currentSymbol = text.charAt(i);
            if (!symbols.containsKey(currentSymbol)){
                symbols.put(currentSymbol, 1);
            } else {
                int currentValue = symbols.get(currentSymbol);
                symbols.put(currentSymbol, currentValue + 1);
            }
        }

        symbols.forEach((key, value) -> System.out.printf("%c: %d time/s\n", key, value));
    }
}

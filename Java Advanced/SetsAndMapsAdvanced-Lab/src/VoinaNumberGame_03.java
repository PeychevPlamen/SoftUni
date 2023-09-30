import java.util.*;
import java.util.stream.Collectors;

public class VoinaNumberGame_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        List<Integer> cardsFirst = Arrays.stream(scanner.nextLine()
                        .split("\\s+"))
                        .map(Integer:: parseInt)
                .collect(Collectors.toList());

        List<Integer> cardsSecond = Arrays.stream(scanner.nextLine()
                        .split("\\s+"))
                        .map(Integer:: parseInt)
                        .collect(Collectors.toList());

        Set<Integer> firstPLayerCards = new LinkedHashSet<>(cardsFirst);
        Set<Integer> secondPLayerCards = new LinkedHashSet<>(cardsSecond);

        int rounds = 50;

        for (int i = 0; i < 50; i++) {
            if (firstPLayerCards.isEmpty() || secondPLayerCards.isEmpty()){
                break;
            }
            int firstNumber = firstPLayerCards.iterator().next();
            firstPLayerCards.remove(firstNumber);
            int secondNumber = secondPLayerCards.iterator().next();
            secondPLayerCards.remove(secondNumber);

            if (firstNumber > secondNumber){
                firstPLayerCards.add(firstNumber);
                firstPLayerCards.add(secondNumber);
            } else if (secondNumber > firstNumber) {
                secondPLayerCards.add(firstNumber);
                secondPLayerCards.add(secondNumber);
            }
        }

        if (firstPLayerCards.size() > secondPLayerCards.size()){
            System.out.println("First player win!");
        } else if(secondPLayerCards.size() > firstPLayerCards.size()){
            System.out.println("Second player win!");
        } else {
            System.out.println("Draw!");
        }

    }
}

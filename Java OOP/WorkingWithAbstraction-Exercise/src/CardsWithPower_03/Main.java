package CardsWithPower_03;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String rank = scanner.nextLine();
        String suit = scanner.nextLine();
        Card card = new Card(CardRankPowers.valueOf(rank), CardSuitPowers.valueOf(suit));

        System.out.printf("Card name: %s of %s; Card power: %d",
                card.getCardRankPowers(),
                card.getCardSuitPowers(),
                card.calculatePower());
    }
}

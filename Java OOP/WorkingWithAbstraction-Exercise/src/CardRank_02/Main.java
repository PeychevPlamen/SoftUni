package CardRank_02;

public class Main {
    public static void main(String[] args) {

        CardRanks[] cards = CardRanks.values();

        System.out.println("Card Ranks:");
        for (CardRanks card : cards) {
            System.out.printf("Ordinal value: %d; Name value: %s%n", card.ordinal(), card.name());
        }
    }
}

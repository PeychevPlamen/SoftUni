package CardsWithPower_03;

public class Card {
    private CardRankPowers cardRankPowers;
    private CardSuitPowers cardSuitPowers;

    public Card(CardRankPowers cardRankPowers, CardSuitPowers cardSuitPowers) {
        this.cardRankPowers = cardRankPowers;
        this.cardSuitPowers = cardSuitPowers;
    }

    public CardRankPowers getCardRankPowers() {
        return cardRankPowers;
    }

    public CardSuitPowers getCardSuitPowers() {
        return cardSuitPowers;
    }

    public int calculatePower(){
        return getCardRankPowers().getValue() + getCardSuitPowers().getValue();
    }
}

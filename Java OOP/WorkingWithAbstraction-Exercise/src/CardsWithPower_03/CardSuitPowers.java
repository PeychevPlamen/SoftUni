package CardsWithPower_03;

public enum CardSuitPowers {
    CLUBS(0), DIAMONDS(13), HEARTS(26), SPADES(39);

    private int value;

    CardSuitPowers(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}

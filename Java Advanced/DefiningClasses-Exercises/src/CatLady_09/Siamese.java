package CatLady_09;

public class Siamese extends Cat{
    private double earSize;

    public Siamese(String breed, String name, double earSize) {
        super(breed, name);
        this.earSize = earSize;
    }

    public double getEarSize() {
        return earSize;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f", super.toString(), getEarSize());
    }
}

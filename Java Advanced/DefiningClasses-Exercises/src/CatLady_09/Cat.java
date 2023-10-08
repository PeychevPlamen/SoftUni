package CatLady_09;

public class Cat {
    private String breed;
    private String name;

    public Cat(String breed, String name) {
        this.breed = breed;
        this.name = name;
    }

    public String getBreed() {
        return breed;
    }

    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        return String.format("%s %s", getBreed(), getName());
    }
}

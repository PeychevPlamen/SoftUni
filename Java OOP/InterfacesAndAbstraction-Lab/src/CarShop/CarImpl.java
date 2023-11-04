package CarShop;

public class CarImpl implements Car {
    private String model;
    private String color;
    private Integer horsePower;
    private String countryProduced;

    public CarImpl(String model, String color, Integer horsePower, String countryProduced) {
        this.model = model;
        this.color = color;
        this.horsePower = horsePower;
        this.countryProduced = countryProduced;
    }

    @Override
    public String getModel() {
        return model;
    }

    public String getColor() {
        return color;
    }

    public Integer getHorsePower() {
        return horsePower;
    }

    @Override
    public String countryProduced() {
        return countryProduced;
    }


    @Override
    public String toString() {
        return String.format("This is %s produced in %s and have %s tires", getModel(), countryProduced(), TIRES);
    }
}

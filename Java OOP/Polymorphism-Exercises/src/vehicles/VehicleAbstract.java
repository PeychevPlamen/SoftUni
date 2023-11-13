package vehicles;

import java.security.DigestException;
import java.text.DecimalFormat;

public abstract class VehicleAbstract implements VehicleInterface {
    private static final DecimalFormat DECIMAL_FORMAT = new DecimalFormat("#.##");
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;


    public VehicleAbstract(double fuelQuantity, double fuelConsumption, double tankCapacity) {
        setFuelQuantity(fuelQuantity);
        this.fuelConsumption = fuelConsumption;
        this.tankCapacity = tankCapacity;
    }

    public double getFuelQuantity() {
        return fuelQuantity;
    }

    public void setFuelQuantity(double fuelQuantity) {

        if (fuelQuantity <= 0){
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        this.fuelQuantity = fuelQuantity;
    }

    public double getFuelConsumption() {
        return fuelConsumption;
    }

    @Override
    public void setFuelConsumption(double fuelConsumption) {
        this.fuelConsumption = fuelConsumption;
    }

    @Override
    public String drive(double distance) {

        if (fuelQuantity >= distance * fuelConsumption) {
            fuelQuantity -= distance * fuelConsumption;
            return String.format("%s travelled %s km", this.getClass().getSimpleName(), DECIMAL_FORMAT.format(distance));
        }
        return String.format("%s needs refueling", this.getClass().getSimpleName());
    }

    @Override
    public void refuel(double liters) {
        if (fuelQuantity + liters > tankCapacity){
            throw new IllegalArgumentException("Cannot fit fuel in tank");
        }
        if (liters <= 0) {
            throw new IllegalArgumentException("Fuel must be a positive number");
        }
        fuelQuantity += liters;
    }

    @Override
    public String toString() {
        return String.format("%s: %.2f", this.getClass().getSimpleName(), getFuelQuantity());
    }
}

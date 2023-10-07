package SpeedRacing_03;

public class Car {
    private String model;
    private double fuelAmount;
    private double fuelNeededPerKm;
    private int distanceTraveled;

    public Car(String model, double fuelAmount, double fuelNeededPerKm) {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelNeededPerKm = fuelNeededPerKm;
        this.distanceTraveled = 0;
    }

    public String getModel() {
        return model;
    }

    public double getFuelAmount() {
        return fuelAmount;
    }

    public int getDistanceTraveled() {
        return distanceTraveled;
    }

    public double getFuelNeededPerKm() {
        return fuelNeededPerKm;
    }

    public boolean drive(int kmToDrive) {
        double neededFuel = kmToDrive * getFuelNeededPerKm();
        if (neededFuel > getFuelAmount()){
            return false;
        }
        this.distanceTraveled += kmToDrive;
        this.fuelAmount -= neededFuel;

        return true;
    }

    @Override
    public String toString() {
        return String.format("%s %.2f %d", getModel(), getFuelAmount(), getDistanceTraveled());
    }
}

package automotiveRepairShop;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Optional;

public class RepairShop {
    private int capacity;
    private List<Vehicle> vehicles;

    public RepairShop(int capacity) {
        this.capacity = capacity;
        this.vehicles = new ArrayList<>();
    }

    public void addVehicle(Vehicle vehicle) {
        if (capacity > vehicles.size()) {
            vehicles.add(vehicle);
        }
    }

    public boolean removeVehicle(String vin) {
        Vehicle vehicleToRemove = null;
        for (Vehicle vehicle : vehicles) {
            if (vehicle.getVIN().equals(vin)) {
                vehicleToRemove = vehicle;
                break;
            }
        }
        return vehicles.remove(vehicleToRemove);
    }

    public int getCount() {
        return vehicles.size();
    }

    public Vehicle getLowestMileage() {
        Optional<Vehicle> lowestMileageVehicle = vehicles.stream()
                .min(Comparator.comparingInt(Vehicle::getMileage));

        return lowestMileageVehicle.orElse(null);
    }

    public String report() {
        StringBuilder sb = new StringBuilder();
        sb.append("Vehicles in the preparatory:").append(System.lineSeparator());
        for (Vehicle vehicle : vehicles) {
            sb.append(vehicle).append(System.lineSeparator());
        }
        return sb.toString();
    }
}
